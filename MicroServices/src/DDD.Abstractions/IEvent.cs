namespace DDD.Abstractions
{
	using System;

	public interface IEvent
	{
		Guid Id { get; }
		string Type { get; }
		DateTime TimeStamp { get; }

	}
}
