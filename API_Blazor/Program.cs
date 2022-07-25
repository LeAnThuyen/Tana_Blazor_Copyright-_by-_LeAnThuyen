using API_Blazor.Data;
using API_Blazor.Entities;
using API_Blazor.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API_Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDbContext<DatabaseContext>((ContextBoundObject, services) =>
            {
                var logger = services.GetService<ILogger<DatabaseConTextSeed>>();
                new DatabaseConTextSeed().SeedAsync(ContextBoundObject, logger).Wait();
            });
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
