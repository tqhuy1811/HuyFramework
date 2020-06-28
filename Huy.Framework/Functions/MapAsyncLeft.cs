using System;
using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public async static Task<Result<TE>> Map<T, TE>(
			this Task<Result<T>> result,
			Func<T, TE> f)
		{
			var awaitedResult = await result;
			if (awaitedResult.Failure)
			{
				return awaitedResult.Error;
			}
			
			return Result<TE>.Ok(f(awaitedResult.Data));
		}
	}
}