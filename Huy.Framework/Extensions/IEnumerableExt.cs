using System;
using System.Collections.Generic;
using System.Linq;
using Huy.Framework.Types;
using static Huy.Framework.Types.UnitExt;

namespace Huy.Framework.Extensions
{
	public static class EnumerableExt
	{
		public static IEnumerable<(int index, T data)> WithIndex<T>(this IEnumerable<T> @this)
		{
			return @this.Select((_,
				i) => (i, _));
		}

		public static Unit ForEach<T>(
			this IEnumerable<T> @this,
			Action<T> func)
		{
			foreach (var item in @this) func(item);

			return Unit();
		}
	}
}