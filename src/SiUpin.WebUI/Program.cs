using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SiUpin.WebUI.Common;
using Syncfusion.Blazor;

namespace SiUpin.WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            const string httpClientName = "SiUpin.WebAPI";

            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense($"MzQ2NDE2QDMxMzgyZTMzMmUzMGtBcm14YTF5dnhWaWd2NUs3Y1ZZb0NxTzNjNmNtc2FUbU9BMkUzZ2hqcXM9");


            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddHttpClient(httpClientName, client =>
            {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });

            builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(httpClientName));

            builder.Services.AddSyncfusionBlazor();

            await builder.Build().RunAsync();
        }
    }
}