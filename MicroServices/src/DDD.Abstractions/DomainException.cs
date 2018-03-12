﻿namespace DDD.Abstractions
{
	using System;

	public class DomainException : Exception
	{
		public DomainException(string message)
			: base(message)
		{ }

		public DomainException(string message, Exception inner)
			: base(message, inner)
		{ }
	}
}
