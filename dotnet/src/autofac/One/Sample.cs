using Autofac;
using Autofac.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.fgq.autofacstudy.One
{

    public interface IOutput
    {
        void Write(string content);
    }

    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }

    public interface IDateWriter
    {
        void WriteDate();
    }


    public class TodayWriter : IDateWriter
    {
        private IOutput _output;
        public TodayWriter(IOutput output)
        {
            this._output = output;
        }

        public void WriteDate()
        {
            this._output.Write(DateTime.Today.ToShortDateString());
        }
    }



    internal class Sample
    {

        private static IContainer Container { get; set; }

        public static void Run()
        {


            Console.WriteLine(nameof(Sample.Run) + " running");

            var builder = new ContainerBuilder();

            builder.RegisterType<TodayWriter>().AsSelf().As<IDateWriter>();
            builder.RegisterType<ConsoleOutput>().AsSelf().As<IOutput>();

            builder.Register((c) => new StringBuilder()).As<StringBuilder>();

            builder.Register(ctx => "HelloWorld");
            Container = builder.Build();

            var tracer = new DefaultDiagnosticTracer();
            tracer.OperationCompleted += (sender, args) =>
            {
                Console.WriteLine(args.TraceContent);
            };

            // Subscribe to the diagnostics with your tracer.
            Container.SubscribeToDiagnostics(tracer);


            WriteDate();

        }
        public static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }

    }
}
