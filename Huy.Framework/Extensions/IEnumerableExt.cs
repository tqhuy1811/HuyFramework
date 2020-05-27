using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Huy.Framework.Types;
using static Huy.Framework.Types.UnitExt;

namespace Huy.Framework.Extensions
{
	public static class IEnumerableExt
	{
		public static IEnumerable<(int index, T data)> WithIndex<T>(this IEnumerable<T> @this)
		{
			return @this.Select((_, i) => (i, _));
		}

		public static Unit ForEach<T>(
			this IEnumerable<T> @this,
			Action<T> func)
		{
			foreach (var item in @this)
			{
				func(item);
			}

			return Unit();
		}
		
		// this maybe outdated in the future
		public static async IAsyncEnumerable<TResult> ToAsyncEnumerable<T, TResult>(
			this IEnumerable<T> @this, 
			Func<T, Task<TResult>> f) 
		{
			var arr = @this.ToArray();
			for (var i = 0; i < arr.Length; i++)
			{
				yield return await f(arr[i]);
			}
		}
	}
}