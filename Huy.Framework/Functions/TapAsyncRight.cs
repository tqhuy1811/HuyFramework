using System;
using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static Task<Result<T>> Tap<T, TE>(
			this Result<T> r,
			Func<T, Task<Result<TE>>> f)
		{
			return r.Bind(f).Map(_ => r.Data);
		}
	}
}