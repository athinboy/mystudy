using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Pipe;
using System;


namespace Org.FGQ.CodeGenerate.Generator
{
    internal class DBToSQLGenerator : GeneratorBase
    {
        private GenerateConfig generateConfig;

        internal DBToSQLGenerator(GenerateConfig generateConfig)
        {
            this.generateConfig = generateConfig ?? throw new ArgumentNullException(nameof(generateConfig));
        }





        public override bool ValidateConfig()
        {
            if (GenerateMode.DBToCode != generateConfig.Mode)
            {
                Console.WriteLine("wrong mode!");
                return false;
            }

            return true;
        }

        public override Work.Work CreateWork(GenerateConfig generateConfig)
        {
            Work.Work work = new Work.Work(generateConfig);

            DBToDDLPipe dBToDDLPipe = new DBToDDLPipe();
            work.InPipes.Add(dBToDDLPipe);

            SQLWorkPipe sqlworkpipe = new SQLWorkPipe("");
            work.OutPipes.Add(sqlworkpipe);

            return work;
        }
    }
}
