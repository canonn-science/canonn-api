namespace Domain.Entities
{
	using System;
	using Microsoft.Extensions.Logging;

	public abstract class LocationReport: Entity
	{
		public string ReportingCommander { get; protected set; }


		protected  LocationReport(ILogger logger, Guid id)
			: base(logger, id)
		{
		}
	}
}
