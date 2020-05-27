using System.Collections.Generic;

namespace Huy.Framework.Types
{
	public class Result<T>
	{
		public bool Success { get;}
		public bool Failure
		{
			get => !Success;
		}

		public IEnumerable<T> AsEnumerable()
		{
			if (Success)
				yield return Data;
		}

		public T Data { get; }
		
		public Error Error { get; }

		public Result(bool success, T data, Error error)
		{
			Success = success;
			Data = data;
			Error = error;
		}		
		
		public static Result<T> Ok(T data) => new Result<T>(true, data, default);
		public static Result<T> Fail(Error error) => new Result<T>(false, default, error);
	}
}