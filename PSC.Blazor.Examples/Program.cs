using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
<<<<<<< HEAD
using Microsoft.Extensions.DependencyInjection;
using PSC.Blazor.Examples.Data;
using System;
using System.Net.Http;
=======
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PSC.Blazor.Examples.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
using System.Threading.Tasks;

namespace PSC.Blazor.Examples
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddSingleton<WeatherForecastService>();

			await builder.Build().RunAsync();
		}
	}
}
