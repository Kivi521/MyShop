using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EShop.Data;

namespace EShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //in order really bulletproof it,
            var host = CreateHostBuilder(args).Build();

            if (args.Length > 0 && args[0].ToLower() == "/seed")
            {
                RunSeeding(host);
                return;
            }

            host.Run();
        }

        private static void RunSeeding(IHost host)
        {
            // scopeFactory is a way outside of the standard web serer to create a scope.
            // the scopeFactory creates a scope for the lifetime of the request.
            // that's wayyou get an instance of that context object that is true throughout an entire request

            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                //之前是ar seeder = host.Services..GetService<EShopSeeder>();有了scope之后改为

                var seeder = scope.ServiceProvider.GetService<EShopSeeder>();
                seeder.SeedAsync().Wait();
            }
        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
