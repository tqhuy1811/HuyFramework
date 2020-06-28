using System;
using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static async Task<Result<TE>> BindAsyncRight<T, TE>(
			this Result<T> r,
			Func<T, Task<Result<TE>>> f)
		{
			if (r.Failure)
			{
				return Result<TE>.Fail(r.Error);
			}

			return await f(r.Data);
		}
	}
}