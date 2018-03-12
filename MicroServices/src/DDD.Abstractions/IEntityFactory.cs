namespace DDD.Abstractions
{
	using System;

	public interface IEntityFactory
	{
		TEntity CreateEntity<TEntity>()
			where TEntity : class, IEntity;

		TEntity CreateEntity<TEntity>(Guid id)
			where TEntity : class, IEntity;
	}
}
