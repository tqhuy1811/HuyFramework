namespace Huy.Framework.Types
{
	public abstract class Error
	{
		protected Error(string message)
		{
			Message = message;
		}

		public string Message { get; }

		public override string ToString()
		{
			return Message;
		}
	}

	public class UnexpectedError: Error
	{
		public UnexpectedError(string message) : base(message)
		{
		}
	}
	
	public class AggregatedError: Error
	{
		public AggregatedError(string message) : base(message)
		{
		}
	}
}