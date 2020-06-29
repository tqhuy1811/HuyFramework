using System;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static Result<T> Using<TDisposable, T>(
			Func<TDisposable> factory,
			Func<TDisposable, Result<T>> f
		) where TDisposable : IDisposable
		{
			using var disposable = factory();
			return f(disposable);
		}
	}
}