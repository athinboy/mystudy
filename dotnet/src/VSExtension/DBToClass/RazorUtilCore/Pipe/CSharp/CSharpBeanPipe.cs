﻿using Org.FGQ.CodeGenerate.Code;
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Work;
using Org.FGQ.CodeGenerate.RazorTag;
using Org.FGQ.CodeGenerate.Util.Code;
using RazorEngineCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Org.FGQ.CodeGenerate.Pipe.CSharp
{
    public class CSharpBeanPipe : WorkPipeBaseT<CSharpWork, CSharpClass>
    {

        private const string fileSuffix = ".cs";

        public override void GenerateT(CSharpWork work, IRazorEngineCompiledTemplate<RazorEngineTemplateBase<CSharpClass>> template, CSharpClass t)
        {

            CSharpBeanModel cSharpBeanModel = work.BeanConfig;

            string beanRootDir = CodeUtil.PrepareCodeRoot(cSharpBeanModel.CodeDiretory, cSharpBeanModel.NamespacePath);


            CSharpClass cSharpClass = t as CSharpClass;

            string result = string.Empty;
            string filePath;

            result = template.Run(instance =>
            {
                instance.Model = cSharpClass;
            });
            filePath = beanRootDir + Path.DirectorySeparatorChar + cSharpClass.ClassName + fileSuffix;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.WriteAllText(filePath, result, new UTF8Encoding(false));




        }

        public override string getRazorFilePath(Work.Work work)
        {
            return FileUtil.GetInternalTemplateFilePath("CSharpBean.cshtml");
        }

        public override void PrePareModel(Work.Work work, PipeBase pipe)
        {
            (work as JavaWorkModel).BeanConfig.DDLConfig.Prepare();
        }

        public override void AddTemplateReference(IRazorEngineCompilationOptionsBuilder builder)
        {
            base.AddTemplateReference(builder);


            builder.AddAssemblyReferenceByName("System.Collections");
            builder.AddAssemblyReference(typeof(CodeUtil)); // by type         
            builder.AddAssemblyReference(typeof(ReverseStrTagHelper)); // by type
        }

        public override IEnumerable<object> GetModels(Work.Work work, PipeBase pipe)
        {
            JavaBeanModel javaBeanConfig = (work as JavaWorkModel).BeanConfig;

            List<ClassBase> models = new List<ClassBase>();

            javaBeanConfig.DDLConfig.Tables.ForEach(t =>
            {
                javaBeanConfig.Table = t;
                t.RelatedClsss = JavaClass.CreateBoClass(t, javaBeanConfig, true);
                models.Add(t.RelatedClsss as JavaClass);
                models.Add((t.RelatedClsss as JavaClass).JavaVoClass);

            });

            return models;


        }
    }
}
