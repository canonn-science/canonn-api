namespace DDD.Abstractions
{
	using System;

	public interface IAggregateFactory
	{
		TAggregate CreateEntity<TAggregate>()
			where TAggregate : class, IAggregate;

		TAggregate CreateEntity<TAggregate>(Guid id)
			where TAggregate : class, IAggregate;
	}
}
