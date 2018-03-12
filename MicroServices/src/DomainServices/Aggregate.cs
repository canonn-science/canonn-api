namespace DomainServices
{
	using System;
	using DDD.Abstractions;
	using Microsoft.Extensions.Logging;

	public abstract class Aggregate : IAggregate
	{
		private readonly IEventDispatcher _eventDispatcher;
		protected readonly ILogger Logger;

		public Guid Id { get; protected set; }
		public int Version { get; protected set; }

		protected Aggregate(ILogger logger, IEventDispatcher eventDispatcher, Guid id)
		{
			if (id == Guid.Empty)
				throw new ArgumentNullException(nameof(id));

			Logger = logger;
			_eventDispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));
			Id = id;
		}

		public void ApplyEvent(IEvent evt)
		{
			_eventDispatcher.DispatchEvent(this, evt);
			Version++;
		}
	}
}
