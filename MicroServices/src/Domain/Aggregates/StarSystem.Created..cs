namespace Domain.Aggregates
{
	using System;
	using DDD.Abstractions;

	public class StarSystemCreatedEvent : IEvent
	{
		public Guid Id { get; set; }
		public string Type { get; set; } = nameof(StarSystemCreatedEvent);
		public int Version { get; set; } = 1;
		public DateTime TimeStamp { get; set; }
		
		public Guid SystemId { get; set; }
		public string Name { get; set; }
	}

	public partial class StarSystem
	{
		public void Apply(StarSystemCreatedEvent evt)
		{
			Id = evt.SystemId;
			Name = evt.Name;
		}
	}
}
