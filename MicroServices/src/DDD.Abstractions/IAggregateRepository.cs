namespace DDD.Abstractions
{
	using System;

	public interface IAggregateRepository
	{
		TEntity LoadAggregate<TEntity>(Guid id, int version = Int32.MaxValue)
			where TEntity : class, IAggregate;
	}
}
