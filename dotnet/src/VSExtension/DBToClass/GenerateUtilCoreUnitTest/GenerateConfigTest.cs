using NUnit.Framework;
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Dispatch;
using Org.FGQ.CodeGenerate.Generator;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Pipe;
using System;

namespace Org.FGQ.CodeGenerateTest
{
	internal class GenerateConfigTest
	{


		[SetUp]
		public void Init()
		{
			 


		}

		[Test]
		public void WriteJson()
		{
			GenerateConfig generateConfig = new GenerateConfig();

			generateConfig.CodeConfig.CSharpConfig = new CSharpConfig
			{
				NamespacePathLowerCase = true,
				NamespacePathOmmit = ""
			};

			generateConfig.DBConfig.MySqlDBConfig = new MySqlDBConfig
			{
				Port = 3306,
				Pwd = "123",
				UserId = "root",
				Server = "localhost"
			};

			generateConfig.CodeConfig = new CodeConfig();
			CSharpConfig cSharpConfig = (generateConfig.CodeConfig.CSharpConfig = new CSharpConfig());
			cSharpConfig.NamespacePathLowerCase = true;
			cSharpConfig.NamespaceName = "Org.Fgq.Code";



			Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(generateConfig, Newtonsoft.Json.Formatting.Indented));

			Assert.IsTrue(true);



		}

	}
}
