namespace Domain.Aggregates
{
	using System;
	using DDD.Abstractions;

	public class StarSystemImporteddEvent : IEvent
	{
		public Guid Id { get; set; }
		public string Type { get; set; } = nameof(StarSystemImporteddEvent);
		public int Version { get; set; } = 1;
		public DateTime TimeStamp { get; set; }

		public int EdsmId { get; set; }
		public int FdevId { get; set; }
		public string Allegiance { get; set; }
	}

	public partial class StarSystem
	{
		public void Apply(StarSystemImporteddEvent evt)
		{
			EdsmId = evt.EdsmId;
			FdevId = evt.FdevId;
			Allegiance = evt.Allegiance;
			LastImported = evt.TimeStamp;
		}
	}
}
