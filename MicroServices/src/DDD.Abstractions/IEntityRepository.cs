namespace DDD.Abstractions
{
	using System;

	public interface IEntityRepository
	{
		TEntity LoadEntity<TEntity>(Guid id)
			where TEntity : class, IEntity;
	}
}
