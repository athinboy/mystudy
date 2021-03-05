using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Redis
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    /// <remarks>
    /// https://redis.io/topics/pipelining
    /// <br/>
    /// nopipeline time elapse:456   value:1000 <br/>
    /// pipeline time elapse:3   value:1000 
    /// </remarks>  
    class ProgramPipelining
    {
        static void Main(string[] args)
        {


            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(Config.Config.Host + ":" + Config.Config.port))
            {
                IServer server = redis.GetServer(Config.Config.Host, Config.Config.port);
                IDatabase database = redis.GetDatabase(1);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int times = 1000;

                for (int i = 0; i < times; i++)
                {
                    database.StringIncrement("testkey");
                }
                sw.Stop();

                RedisValue value = database.StringGet("testkey");
                System.Console.WriteLine("nopipeline time elapse:{0}   value:{1} ", sw.ElapsedMilliseconds.ToString(), times.ToString());



                sw.Reset();
                sw.Start();
                for (int i = 0; i < times; i++)
                {
                    Task<long> task = database.StringIncrementAsync("testkey");
                    //database.Wait(task);                
                }
                sw.Stop();

                value = database.StringGet("testkey");
                System.Console.WriteLine("pipeline time elapse:{0}   value:{1} ", sw.ElapsedMilliseconds.ToString(), times.ToString());





            }






        }
    }
}
