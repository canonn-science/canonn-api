using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EddnEventBridgeSample
{
	public class Application
	{
		private readonly ILogger _logger;

		public Application(ILogger<Application> logger)
		{
			_logger = logger;
		}

		public async Task Run(CancellationToken token)
		{
			_logger?.LogInformation("Application is starting");

			while (true)
			{
				if (!token.IsCancellationRequested)
				{
					await Task.Delay(TimeSpan.FromSeconds(2));
					_logger?.LogInformation("Application is running...");
				}

				if (token.IsCancellationRequested)
				{
					break;
				}
			}

			_logger?.LogInformation("Application completed");
		}
	}
}
