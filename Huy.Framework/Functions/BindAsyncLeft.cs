using System;
using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static async Task<Result<TE>> BindAsyncLeft<T, TE>(this Task<Result<T>> result,
			Func<T, Result<TE>> f)
		{
			var firstResult = await result;

			return (firstResult.Failure) switch
			{
				true => Result<TE>.Fail(firstResult.Error),
				false => f(firstResult.Data)
			};
		}
	}
}