using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyBlog.Data.EF;

namespace MyBlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //IHost host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var dbInitialize = services.GetService<DbInitializer>();
            //        dbInitialize.Seed().Wait();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetService<ILogger<Program>>();
            //        logger.LogError(ex, "An Error Occured");
            //    }
            //}
            //host.Run();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
