namespace Domain.Entities
{
	using System;
	using Microsoft.Extensions.Logging;

	public class StarSystem : Entity
	{
		public StarSystem(ILogger<StarSystem> logger, Guid id)
			: base(logger, id)
		{ }
	}
}
