using System;
using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace EddnEventBridgeSample
{
	public class EventStoreConnector : IDisposable
	{
		private readonly ILogger<EventStoreConnector> _logger;
		private readonly IEventStoreConnection _connection;

		public EventStoreConnector(ILogger<EventStoreConnector> logger)
		{
			_logger = logger;

			_connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
			_connection.ConnectAsync().Wait();
		}

		public void CreateDetectedSystemEvent(string allegiance, DetectedSystem detectedSystem)
		{
			_connection.AppendToStreamAsync(
				"system_detected_" + allegiance.ToLowerInvariant(),
				ExpectedVersion.Any,
				CreateEventDataForSystem(detectedSystem)
			);
		}

		private EventData CreateEventDataForSystem(DetectedSystem detectedSystem)
		{
			var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(detectedSystem));
			return new EventData(Guid.NewGuid(), "SystemDetected", true, data, null);
		}

		public void Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_connection.Close();
				_connection.Dispose();
			}
		}
	}
}
