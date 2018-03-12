﻿namespace DDD.Abstractions
{
	using System;

	public interface IEvent
	{
		Guid Id { get; }
		string Type { get; }
		int Version { get; }
		DateTime TimeStamp { get; }
	}
}
