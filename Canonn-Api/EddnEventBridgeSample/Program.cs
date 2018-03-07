using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace EddnEventBridgeSample
{
	class Program
	{
		static async Task<int> Main(string[] args)
		{
			InitializeLogging();

			try
			{
				// Actual application code
				var sp = BuildServiceProvider();

				using (var cts = new CancellationTokenSource())
				{
					Console.CancelKeyPress += (s, e) =>
					{
						Log.Logger.Information("Ctrl-C received. Trying to shutdown gracefully.");
						cts.Cancel(false);
					};

					var app = sp.GetRequiredService<Application>();
					await app.Run(cts.Token);
				}
			}
			catch (Exception ex)
			{
				Log.Logger.Fatal(ex, "Fatal error on application execution.");
				return 1;
			}
			finally
			{
				Log.CloseAndFlush();
			}

#if DEBUG
			if (System.Diagnostics.Debugger.IsAttached)
			{
				Console.ReadKey();
			}
#endif

			return 0;
		}

		private static void InitializeLogging()
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.Enrich.FromLogContext()
				.Enrich.WithProperty("Application", "EddnEventBridgeSample")
				.Enrich.WithProcessId()
				.Enrich.WithProcessName()
				.Enrich.WithThreadId()
				.Enrich.WithMachineName()
				.Enrich.WithMemoryUsage()
				.Enrich.WithUserName()
				.WriteTo.Console()
				.WriteTo.Seq("http://localhost:5341")
				.CreateLogger();
		}

		private static IServiceProvider BuildServiceProvider()
		{
			var services = new ServiceCollection()
				.AddLogging(lb => lb.AddSerilog())
				.AddTransient<Application>();

			return services.BuildServiceProvider();
		}
	}
}
