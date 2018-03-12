﻿namespace DomainServices
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using DDD.Abstractions;
	using Microsoft.Extensions.Logging;

	public class TypeBasedEventDispatcher<TAggregate> : IEventDispatcher<TAggregate>
		where TAggregate: class, IAggregate
	{
		private readonly ILogger<TypeBasedEventDispatcher<TAggregate>> _logger;
		private readonly IReadOnlyDictionary<Type, MethodInfo> _eventHandler;

		public TypeBasedEventDispatcher(ILogger<TypeBasedEventDispatcher<TAggregate>> logger)
		{
			_logger = logger;

			_eventHandler = typeof(TAggregate).GetMethods()
				.Where(mi => mi.Name == "Apply" && mi.GetParameters().Length == 1)
				.Select(mi => new
				{
					Type = mi.GetParameters()[0].ParameterType,
					MethodInfo = mi,
				})
				.ToDictionary(i => i.Type, i => i.MethodInfo);
		}

		public void DispatchEvent(IAggregate aggregate, IEvent evt)
		{
			var eventType = evt.GetType();

			if (!_eventHandler.TryGetValue(eventType, out var methodInfo))
				throw new DomainException($"No event handler for event type {eventType.Name} found on aggregate type {aggregate.GetType().Name}");

			methodInfo.Invoke(aggregate, new object[] { evt });
		}
	}
}
