using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<IHostedServiceImpl>();
                });

    }



    public class IHostedServiceImpl : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("IHostedServiceImpl:" + nameof(StartAsync));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("IHostedServiceImpl:" + nameof(StopAsync));
            return Task.CompletedTask;
        }
    }
}