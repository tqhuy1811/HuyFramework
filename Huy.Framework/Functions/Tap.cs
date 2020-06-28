using System;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static Result<T> Tap<T, TE>(
			this Result<T> r,
			Func<T, Result<TE>> f)
		{
			return r.Bind(f).Map(_ => r.Data);
		}
	}
}