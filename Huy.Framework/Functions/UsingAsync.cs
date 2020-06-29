using System;
using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static async Task<Result<T>> Using<TDisposable, T>(
			Func<TDisposable> factory,
			Func<TDisposable, Task<Result<T>>> f
		) where TDisposable : IDisposable
		{
			using var disposable = factory();
			return await f(disposable);
		}
	}
}