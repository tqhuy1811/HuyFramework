using System;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static Result<TE> Map<T, TE>(
			this Result<T> result,
			Func<T, TE> f)
		{
			if (result.Failure)
			{
				return result.Error;
			}
			
			return Result<TE>.Ok(f(result.Data));
		}
	}
}