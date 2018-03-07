using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ionic.Zlib;
using Microsoft.Extensions.Logging;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;

namespace EddnEventBridgeSample
{
	public class EddnEventStreamReader
	{
		private readonly ILogger<EddnEventStreamReader> _logger;
		private readonly EventStoreConnector _eventStoreConnector;

		public EddnEventStreamReader(ILogger<EddnEventStreamReader> logger, EventStoreConnector eventStoreConnector)
		{
			_logger = logger;
			_eventStoreConnector = eventStoreConnector ?? throw new ArgumentNullException(nameof(eventStoreConnector));
		}

		public Task Start(CancellationToken token)
		{
			using (var eddnClient = new SubscriberSocket())
			{
				var address = "tcp://eddn.edcd.io:9500";
				eddnClient.Connect(address);
				eddnClient.SubscribeToAnyTopic();

				while (!token.IsCancellationRequested)
				{
					ReadAllReceievedMessages(eddnClient);
				}

				eddnClient.Unsubscribe(String.Empty);
				eddnClient.Disconnect(address);
			}

			return Task.CompletedTask;
		}

		private void ReadAllReceievedMessages(SubscriberSocket eddnClient)
		{
			var decompressedData = ZlibStream.UncompressBuffer(eddnClient.ReceiveFrameBytes());
			var dataJson = Encoding.UTF8.GetString(decompressedData);
			// free up the memory
			decompressedData = new byte[0];

			var message = JsonConvert.DeserializeObject<EddnMessageContainer>(dataJson);
			if (message.Schema == "https://eddn.edcd.io/schemas/journal/1"
			    && message.Message["event"] == "FSDJump")
			{
				string allegiance = message.Message.SystemAllegiance;

				if (!_loggedAllegiances.Contains(allegiance))
				{
					_loggedAllegiances.Add(allegiance);
					_logger?.LogInformation("Received FSD jump event from EDDN into new area {Allegiance}", allegiance);
				}

				if (allegiance == "Guardian" || allegiance == "Thargoid" || allegiance == "PilotsFederation")
				{
					string systemName = message.Message.StarSystem;
					var coords = new float[] { message.Message.StarPos[0], message.Message.StarPos[1], message.Message.StarPos[2] };

					_logger.LogInformation("System {SystemName} for {Allegiance} found at @{Coordinates}", systemName, allegiance, coords);

					var detectedSystem = new DetectedSystem(systemName, coords);
					_eventStoreConnector.CreateDetectedSystemEvent(allegiance, detectedSystem);
				}
			}
		}

		private HashSet<string> _loggedAllegiances = new HashSet<string>();
	}
}
