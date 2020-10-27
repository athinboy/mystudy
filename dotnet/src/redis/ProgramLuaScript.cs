using System;
using System.Collections.Generic;
using StackExchange.Redis;

namespace Redis
{
    class ProgramLuaScript
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConfigurationOptions config = new ConfigurationOptions
            {
                EndPoints =
                {
                    { "redis0", 6379 },
                    { "redis1", 6380 }
                },
                CommandMap = CommandMap.Create(new HashSet<string>
                { // EXCLUDE a few commands
                    "INFO", "CONFIG", "CLUSTER",
                    "PING", "ECHO", "CLIENT"
                }, available: false),
                KeepAlive = 180,
                DefaultVersion = new Version(2, 8, 8),
                Password = "changeme"
            };


            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(Config.Config.Host + ":" + Config.Config.port))
            {
                IServer server = redis.GetServer(Config.Config.Host, Config.Config.port);
                IDatabase database = redis.GetDatabase(0);
                database.StringSet("testkey", "testvalue");

                RedisValue value = database.StringGet("testkey");
                System.Console.WriteLine(value.ToString());


                const string Script = "redis.call('set', @key, @value)";
                var prepared = LuaScript.Prepare(Script);
                var loaded = prepared.Load(server);

                loaded.Evaluate(database, new { key = "key2", value = "value2" });
                value = database.StringGet("key2");
                System.Console.WriteLine(value.ToString());

                // var result = database.Execute("flushdb");
                // System.Console.WriteLine(result.ToString());



            }






        }
    }
}
