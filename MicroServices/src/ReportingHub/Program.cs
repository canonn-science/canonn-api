using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace ReportingHub
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
				.Enrich.FromLogContext()
				.Enrich.WithMachineName()
				.Enrich.WithMemoryUsage()
				.Enrich.WithProcessId()
				.Enrich.WithProcessName()
				.Enrich.WithThreadId()
				.WriteTo.Console()
				.WriteTo.Seq("http://localhost:5341")
				.CreateLogger();

			try
			{
				BuildWebHost(args).Run();
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureLogging(lb => lb.AddSerilog())
				.UseStartup<Startup>()
				.Build();
	}
}
