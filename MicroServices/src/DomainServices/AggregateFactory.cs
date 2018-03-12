namespace DomainServices
{
	using System;
	using System.Reflection;
	using DDD.Abstractions;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Logging;

	public class AggregateFactory : IAggregateFactory
	{
		private readonly ILogger<AggregateFactory> _logger;
		private readonly IServiceProvider _serviceProvider;

		public AggregateFactory(ILogger<AggregateFactory> logger, IServiceProvider serviceProvider)
		{
			_logger = logger;
			_serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
		}

		public TEntity CreateEntity<TEntity>()
			where TEntity : class, IAggregate
		{
			return CreateEntity<TEntity>(Guid.NewGuid());
		}

		public TAggregate CreateEntity<TAggregate>(Guid id)
			where TAggregate : class, IAggregate
		{
			var entitytype = typeof(TAggregate);
			var ctor = GetEntityConstructor<TAggregate>(entitytype);

			try
			{
				var logger = _serviceProvider.GetService<ILogger<TAggregate>>();
				var dispatcher = _serviceProvider.GetService<IEventDispatcher<TAggregate>>();

				return (TAggregate) ctor.Invoke(new object[] { logger, dispatcher, id });
			}
			catch (Exception ex)
			{
				throw new DomainException($"An error occured while instanciating an Entity of type {entitytype.Name}", ex);
			}
		}

		private ConstructorInfo GetEntityConstructor<TAggregate>(Type entityType)
			where TAggregate: class, IAggregate
		{
			var ctor = entityType.GetConstructor(new[]
			{
				typeof(ILogger<TAggregate>),
				typeof(IEventDispatcher<TAggregate>),
				typeof(Guid)
			});

			if (ctor == null)
				throw new DomainException($"Default constructor of Entity Type {entityType.Name} not found");

			return ctor;
		}
	}
}
