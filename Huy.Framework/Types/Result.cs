using System;
using System.Collections.Generic;

namespace Huy.Framework.Types
{
	public readonly struct Result<T>
	{
		private readonly T _data;
		public bool Success { get;}
		public bool Failure => !Success;

		public IEnumerable<T> AsEnumerable()
		{
			if (Success)
				yield return Data;
		}

		public T Data
		{
			get
			{
				if(Failure) 
					throw new InvalidOperationException($"{typeof(T)} is invalid");
				return _data;
			}
		}

		public Error Error { get; }

		private Result(bool success, T data, Error error)
		{
			Success = success;
			_data = data;
			Error = error;
		}		
		
		public static Result<T> Ok(T data) => new Result<T>(true, data, default);
		public static Result<T> Fail(Error error) => new Result<T>(false, default, error);
		
		
		public static implicit operator Result<T>(Error e)
		{
			return Fail(e);
		}
	}
}