using System;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static Result<TE> Bind<T, TE>(
			this Result<T> r,
			Func<T, Result<TE>> f)
		{
			return (r.Failure) switch
			{
				true => Result<TE>.Fail(r.Error),
				false => f(r.Data)
			};
		}
	}
}