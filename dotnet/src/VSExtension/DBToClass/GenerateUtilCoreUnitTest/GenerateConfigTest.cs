using Newtonsoft.Json;
using NUnit.Framework;
using Org.FGQ.CodeGenerate.Config;
using Org.FGQ.CodeGenerate.Config.CSharp;
using Org.FGQ.CodeGenerate.Dispatch;
using Org.FGQ.CodeGenerate.Generator;
using Org.FGQ.CodeGenerate.Model;
using Org.FGQ.CodeGenerate.Model.DDL;
using Org.FGQ.CodeGenerate.Pipe;
using System;
using System.Text.Json;

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
				NamespacePathOmmit = "Org.FGQ.BaseInfo.Entity"
			};
			generateConfig.DBConfig.DataBaseName = "base_info";
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
			cSharpConfig.NamespaceName = "Org.FGQ.BaseInfo";
			CSharpBeanConfig beanConfig = new CSharpBeanConfig();
			cSharpConfig.BeanConfig = beanConfig;
			beanConfig.ProjectRoot = @"C:\fgq\github\store\code\backend\src\BaseInfo\BaseInfoService.Entity";
			beanConfig.CodeRootRelation = "";
			beanConfig.BeanNamespaceName = "Entity";

 

			Console.WriteLine(JsonConvert.SerializeObject(
				generateConfig,
				Formatting.Indented,
				new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					MissingMemberHandling = MissingMemberHandling.Ignore
					
				}));
			Assert.Pass();



		}

	}
}
