using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api
{
    public class Program
    {
        private static IConfiguration Configuration
        {
            get 
            {
                String env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
                

                return new ConfigurationBuilder()
                        .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false)
                        .AddJsonFile($"appsettings.{env}.json", optional: true)
                        .AddEnvironmentVariables()
                        .Build();
            }
        }

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                //.WriteTo.Debug(Serilog.Events.LogEventLevel.Information)
                //.WriteTo.File("Logs.txt")
                .CreateLogger();


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseConfiguration(Configuration);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
