using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EddnEventBridgeSample
{
	public class Application
	{
		private readonly ILogger _logger;
		private readonly EddnEventStreamReader _streamReader;

		public Application(ILogger<Application> logger, EddnEventStreamReader streamReader)
		{
			_logger = logger;
			_streamReader = streamReader ?? throw new ArgumentNullException(nameof(streamReader));
		}

		public async Task Run(CancellationToken token)
		{
			_logger?.LogInformation("Application is starting");

			_streamReader.Start(token);

			while (!token.IsCancellationRequested)
			{
				await Task.Delay(TimeSpan.FromSeconds(2));
				_logger?.LogInformation("Application is running...");

				if (token.IsCancellationRequested)
				{
					break;
				}
			}

			_logger?.LogInformation("Application completed");
		}
	}
}
