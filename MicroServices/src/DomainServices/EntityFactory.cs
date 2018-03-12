namespace DomainServices
{
	using System;
	using System.Reflection;
	using DDD.Abstractions;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Logging;

	public class EntityFactory : IEntityFactory
	{
		private readonly ILogger<EntityFactory> _logger;
		private readonly IServiceProvider _serviceProvider;

		public EntityFactory(ILogger<EntityFactory> logger, IServiceProvider serviceProvider)
		{
			_logger = logger;
			_serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
		}

		public TEntity CreateEntity<TEntity>()
			where TEntity : class, IEntity
		{
			return CreateEntity<TEntity>(Guid.NewGuid());
		}

		public TEntity CreateEntity<TEntity>(Guid id)
			where TEntity : class, IEntity
		{
			var entitytype = typeof(TEntity);
			var ctor = GetEntityConstructor<TEntity>(entitytype);

			try
			{
				var logger = _serviceProvider.GetService<ILogger<TEntity>>();

				return (TEntity) ctor.Invoke(new object[] { logger, id });
			}
			catch (Exception ex)
			{
				throw new DomainException($"An error occured while instanciating an Entity of type {entitytype.Name}", ex);
			}
		}

		private ConstructorInfo GetEntityConstructor<TEntity>(Type entityType)
		{
			var ctor = entityType.GetConstructor(new[]
			{
				typeof(ILogger<TEntity>),
				typeof(Guid)
			});

			if (ctor == null)
				throw new DomainException($"Default constructor of Entity Type {entityType.Name} not found");

			return ctor;
		}
	}
}
