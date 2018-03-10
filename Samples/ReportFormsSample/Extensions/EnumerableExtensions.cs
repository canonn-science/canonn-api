﻿using System.Linq;

// ReSharper disable once CheckNamespace
namespace System.Collections.Generic
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
			=> self.Select((item, index) => (item, index));
	}
}
