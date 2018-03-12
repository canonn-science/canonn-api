namespace DDD.Abstractions
{
	using System;

	public interface IAggregate
	{
		Guid Id { get; }
		int Version { get; }

		void ApplyEvent(IEvent evt);
	}
}
