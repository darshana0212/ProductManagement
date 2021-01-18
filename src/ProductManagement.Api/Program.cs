using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.RollingFileAlternate;
using Serilog.Formatting.Json;

namespace ProductManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .ConfigureAppConfiguration(
                        (hostingContext, config) => config
                        .AddEnvironmentVariables("ProductManagementApi_")
                                .AddJsonFile("appsettings.json", false, true)
                                .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true)
                                .AddCommandLine(args))
                    .ConfigureLogging(
                            (hostingContext, logging) => logging
                                .AddProvider(CreateLoggerProvdier(hostingContext.Configuration)));
                });
        private static SerilogLoggerProvider CreateLoggerProvdier(IConfiguration configuration)
        {
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .WriteTo.RollingFileAlternate(new JsonFormatter(), "./logs", fileSizeLimitBytes: 100000000, retainedFileCountLimit: 30)
                .ReadFrom.Configuration(configuration);
                
            return new SerilogLoggerProvider(loggerConfiguration.CreateLogger());
        }
    }
}
