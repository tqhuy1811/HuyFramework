using System;
using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static async Task<Result<T>> Tap<T, TE>(
			this Task<Result<T>> r,
			Func<T, Result<TE>> f)
		{
			var awaitedResult = await r;
			return awaitedResult.Tap(f);
		}
	}
}