using System;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static Result<T> Try<T>(Func<Result<T>> f)
		{
			try
			{
				return f();
			}
			catch (Exception e)
			{
				return Result<T>.Fail(new UnExpectedError(e.Message));
			}
		}
	}
}