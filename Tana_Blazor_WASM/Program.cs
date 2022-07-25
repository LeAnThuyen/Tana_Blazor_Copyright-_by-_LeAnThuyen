using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tana_Blazor_WASM.Services;

namespace Tana_Blazor_WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddTransient<ITaskAPIClient, TaskAPIClient>();
            builder.Services.AddTransient<IUserClient, UsersClient>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });

            await builder.Build().RunAsync();
        }
    }
}
