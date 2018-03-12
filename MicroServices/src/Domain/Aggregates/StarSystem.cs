namespace Domain.Aggregates
{
	using System;
	using Microsoft.Extensions.Logging;
	using DDD.Abstractions;
	using DomainServices;

	public partial class StarSystem : Aggregate
	{
		public string Name { get; protected set; }
		public DateTime? LastImported { get; protected set; }
		public int EdsmId { get; protected set; }
		public int FdevId { get; protected set; }
		public string Allegiance { get; protected set; }

		public StarSystem(ILogger<StarSystem> logger, IEventDispatcher<StarSystem> dispatcher, Guid id)
			: base(logger, dispatcher, id)
		{ }
	}
}
