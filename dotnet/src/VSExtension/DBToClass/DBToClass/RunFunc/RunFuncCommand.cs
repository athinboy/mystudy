
using System;
using System.ComponentModel.Design;
using System.Globalization;
using Task = System.Threading.Tasks.Task;


using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.Linq;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using Mono.Cecil;
using ICSharpCode.ILSpy.AddIn;
using DTEConstants = EnvDTE.Constants;

namespace DBToClass.RunFunc
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class RunFuncCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 4132;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("{80DFFED1-B16A-4E9F-92E7-5FBC5899DDB7}");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        protected DBToClassPackage owner;

        /// <summary>
        /// Initializes a new instance of the <see cref="RunFuncCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private RunFuncCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            this.owner = package as DBToClassPackage;
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static RunFuncCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {

            // Switch to the main thread - the call to AddCommand in RunFuncCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new RunFuncCommand(package, commandService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            string title = "RunFuncCommand";

            // Show a message box to prove we were here
            VsShellUtilities.ShowMessageBox(
                this.package,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
            OnExecute(sender, e);
        }
        protected async void OnExecute(object sender, EventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var textView = Utils.GetCurrentViewHost(owner)?.TextView;
            if (textView == null)
            {
                return;
            }
            SnapshotPoint caretPosition = textView.Caret.Position.BufferPosition;
            var roslynDocument = GetRoslynDocument();
            if (roslynDocument == null)
            {
                owner.ShowMessage("This element is not analyzable in current view.");
                return;
            }
            var ast = await roslynDocument.GetSyntaxRootAsync().ConfigureAwait(false);
            var model = await roslynDocument.GetSemanticModelAsync().ConfigureAwait(false);
            var node = ast.FindNode(new TextSpan(caretPosition.Position, 0), false, true);
            if (node == null)
            {
                owner.ShowMessage(OLEMSGICON.OLEMSGICON_WARNING, "Can't show ILSpy for this code element!");
                return;
            }

            var symbol = GetSymbolResolvableByILSpy(model, node);
            if (symbol == null)
            {
                owner.ShowMessage(OLEMSGICON.OLEMSGICON_WARNING, "Can't show ILSpy for this code element!");
                return;
            }

            var roslynProject = roslynDocument.Project;
            var refsmap = GetReferences(roslynProject);
            var symbolAssemblyName = symbol.ContainingAssembly?.Identity?.Name;

            // Add our own project as well (not among references)
            var project = FindProject(owner.DTE.Solution.Projects.OfType<EnvDTE.Project>(), roslynProject.FilePath);

            if (project == null)
            {
                owner.ShowMessage(OLEMSGICON.OLEMSGICON_WARNING, "Can't show ILSpy for this code element!");
                return;
            }

            string assemblyName = roslynDocument.Project.AssemblyName;
            string projectOutputPath = Utils.GetProjectOutputAssembly(project, roslynProject);
            Console.WriteLine(nameof(assemblyName) + ":" + assemblyName);
            Console.WriteLine(nameof(projectOutputPath) + ":" + projectOutputPath);
        }


        public class DetectedReference
        {
            public DetectedReference(string name, string assemblyFile, bool isProjectReference)
            {
                this.Name = name;
                this.AssemblyFile = assemblyFile;
                this.IsProjectReference = isProjectReference;
            }

            public string Name { get; private set; }
            public string AssemblyFile { get; private set; }
            public bool IsProjectReference { get; private set; }
        }


        protected Dictionary<string, DetectedReference> GetReferences(Microsoft.CodeAnalysis.Project parentProject)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var dict = new Dictionary<string, DetectedReference>();
            foreach (var reference in parentProject.MetadataReferences)
            {
                using (var assemblyDef = AssemblyDefinition.ReadAssembly(reference.Display))
                {
                    string assemblyName = assemblyDef.Name.Name;
                    string resolvedAssemblyFile = AssemblyFileFinder.FindAssemblyFile(assemblyDef, reference.Display);
                    dict.Add(assemblyName, new DetectedReference(assemblyName, resolvedAssemblyFile, false));
                }
            }
            foreach (var projectReference in parentProject.ProjectReferences)
            {
                var roslynProject = owner.Workspace.CurrentSolution.GetProject(projectReference.ProjectId);
                if (roslynProject != null)
                {
                    var project = FindProject(owner.DTE.Solution.Projects.OfType<EnvDTE.Project>(), roslynProject.FilePath);
                    if (project != null)
                    {
                        dict.Add(roslynProject.AssemblyName,
                            new DetectedReference(roslynProject.AssemblyName, Utils.GetProjectOutputAssembly(project, roslynProject), true));
                    }
                }
            }
            return dict;
        }

        protected EnvDTE.Project FindProject(IEnumerable<EnvDTE.Project> projects, string projectFile)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            foreach (var project in projects)
            {
                switch (project.Kind)
                {
                    case DTEConstants.vsProjectKindSolutionItems:
                        // This is a solution folder -> search in sub-projects
                        var subProject = FindProject(
                            project.ProjectItems.OfType<EnvDTE.ProjectItem>().Select(pi => pi.SubProject).OfType<EnvDTE.Project>(),
                            projectFile);
                        if (subProject != null)
                            return subProject;
                        break;

                    case DTEConstants.vsProjectKindUnmodeled:
                        // Skip unloaded projects completely
                        break;

                    default:
                        // Match by project's file name
                        if (project.FileName == projectFile)
                            return project;
                        break;
                }
            }

            return null;
        }

        ISymbol GetSymbolResolvableByILSpy(SemanticModel model, SyntaxNode node)
        {
            var current = node;
            while (current != null)
            {
                var symbol = model.GetSymbolInfo(current).Symbol;
                if (symbol == null)
                {
                    symbol = model.GetDeclaredSymbol(current);
                }

                // ILSpy can only resolve some symbol types, so allow them, discard everything else
                if (symbol != null)
                {
                    switch (symbol.Kind)
                    {
                        case SymbolKind.ArrayType:
                        case SymbolKind.Event:
                        case SymbolKind.Field:
                        case SymbolKind.Method:
                        case SymbolKind.NamedType:
                        case SymbolKind.Namespace:
                        case SymbolKind.PointerType:
                        case SymbolKind.Property:
                            break;
                        default:
                            symbol = null;
                            break;
                    }
                }

                if (symbol != null)
                    return symbol;

                current = current is IStructuredTriviaSyntax
                    ? ((IStructuredTriviaSyntax)current).ParentTrivia.Token.Parent
                    : current.Parent;
            }

            return null;
        }



        private Microsoft.CodeAnalysis.Document GetRoslynDocument()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var document = owner.DTE.ActiveDocument;
            var id = owner.Workspace.CurrentSolution.GetDocumentIdsWithFilePath(document.FullName).FirstOrDefault();
            if (id == null)
                return null;

            return owner.Workspace.CurrentSolution.GetDocument(id);
        }

    }
}
