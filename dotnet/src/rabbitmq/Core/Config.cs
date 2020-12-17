using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using System.IO;

namespace Core
{
    public class Config
    {



        private static Config instance = null;

        public static Config GetInstance()
        {
            if (instance == null)
            {
                lock (typeof(Config))
                {
                    if (instance == null)
                    {
                        instance = new Config();
                        var configurationBuilder = new ConfigurationBuilder()
                                             .SetBasePath(Directory.GetCurrentDirectory())
                                                                  .AddJsonFile("config.json");
                        configurationBuilder.Build().Bind(instance);

                    }



                }
            }
            return instance;
        }

    }
}
