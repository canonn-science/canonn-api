namespace Domain.Entities
{
	using System;
	using Microsoft.Extensions.Logging;
	using DDD.Abstractions;

	public abstract class Entity : IEntity
	{
		protected readonly ILogger Logger;

		public Guid Id { get; }

		protected Entity(ILogger logger, Guid id)
		{
			if (id == Guid.Empty)
				throw new ArgumentNullException(nameof(id));

			Logger = logger;
			Id = id;
		}
	}
}
