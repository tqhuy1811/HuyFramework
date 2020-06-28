using System;
using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static async Task<Result<TE>> Map<T, TE>(
			this Result<T> result,
			Func<T, Task<Result<TE>>> f)
		{
			return await result.Bind(f);
		}
	}
}