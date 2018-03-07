using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace DetectedSystemsProcessor
{
	class Program
	{
		static void Main(string[] args)
		{
			bool aborting = false;

			Console.CancelKeyPress += (s, e) =>
			{
				Console.WriteLine("Aborting...");
				aborting = true;
			};

			using (var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113)))
			{
				connection.ConnectAsync().Wait();

				var subscription1 = connection.ConnectToPersistentSubscription("system_detected_guardian", "group1", EventAppeared);
				var subscription2 = connection.ConnectToPersistentSubscription("system_detected_pilotsfederation", "group1", EventAppeared);
				var subscription3 = connection.ConnectToPersistentSubscription("system_detected_thargoid", "group1", EventAppeared);

				while (!aborting)
				{
					Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();
				}

				var wait = TimeSpan.FromSeconds(5);
				subscription1.Stop(wait);
				subscription2.Stop(wait);
				subscription3.Stop(wait);

				connection.Close();
			}

			Console.WriteLine("END");
		}

		private static Task EventAppeared(EventStorePersistentSubscriptionBase eventStorePersistentSubscriptionBase, ResolvedEvent resolvedEvent, int? arg3)
		{
			var data = Encoding.UTF8.GetString(resolvedEvent.Event.Data);
			
			Console.WriteLine($"Event from stream {resolvedEvent.OriginalStreamId} received: {data}");
			eventStorePersistentSubscriptionBase.Acknowledge(resolvedEvent.Event.EventId);

			return Task.CompletedTask;
		}
	}
}
