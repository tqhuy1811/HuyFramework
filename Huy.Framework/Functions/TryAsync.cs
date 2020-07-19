using System;
using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static async Task<Result<T>> Try<T>(Func<Task<Result<T>>> f)
		{
			try
			{
				return await f();
			}
			catch (Exception e)
			{
				return Result<T>.Fail(new UnexpectedError(e.Message));
			}
		}
	}
}