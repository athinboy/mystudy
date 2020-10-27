using System;
using System.Collections.Generic;
using StackExchange.Redis;

namespace Redis
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    /// <remarks>https://redis.io/topics/pipelining</remarks>
    class ProgramPipelining
    {
        static void Main(string[] args)
        {



            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(Config.Config.Host + ":" + Config.Config.port))
            {
                IServer server = redis.GetServer(Config.Config.Host, Config.Config.port);
                IDatabase database = redis.GetDatabase(1);

                for (int i = 0; i < 1000; i++)
                {
                    database.StringIncrement("testkey");
                }

                RedisValue value = database.StringGet("testkey");
                System.Console.WriteLine(value.ToString());


            }






        }
    }
}
