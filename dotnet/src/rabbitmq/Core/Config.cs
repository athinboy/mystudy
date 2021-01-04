using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using System.IO;

namespace org.fgq.study.dotnet.rabbitmq.Core
{
    public class Config
    {



        private static Config instance = null;

        public string QueueName1 { get; set; }="q1";
        public string QueueName2 { get; set; }="q2";
        public string HostName { get; set; }="localhost" ;

        public static Config GetInstance()
        {
            if (instance == null)
            {
                lock (typeof(Config))
                {
                    if (instance == null)
                    {
                        instance = new Config();                
                        //System.Console.WriteLine(System.AppContext.BaseDirectory);
                       
                        var configurationBuilder = new ConfigurationBuilder()
                                             .SetBasePath(System.AppContext.BaseDirectory)
                                                                  .AddJsonFile("config.json");
                        configurationBuilder.Build().Bind(instance);

                    }



                }
            }
            return instance;
        }

    }
}
