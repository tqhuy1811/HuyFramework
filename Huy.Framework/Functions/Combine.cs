using System;
using System.Collections.Generic;
using System.Linq;
using Huy.Framework.Types;

namespace Huy.Framework.Functions
{
	public static partial class FuncExt
	{
		public static Result<T[]> Combine<T>(
			this IEnumerable<Result<T>> results,
			string errorMessageSeparator = ",",
			Func<string, Error> func = null)
		{
			var resultsArr = results.ToArray();
			if (resultsArr.All(r => r.Success))
			{
				return Result<T[]>.Ok(resultsArr.Select(r => r.Data).ToArray());
			}

			var errorMessage = string.Join(
				errorMessageSeparator,
				resultsArr.Select(_ => _.ToString()));

			var error = func == null ? new AggregatedError(errorMessage) : func(errorMessage); 

			return Result<T[]>.Fail(error);
		}
	}
}