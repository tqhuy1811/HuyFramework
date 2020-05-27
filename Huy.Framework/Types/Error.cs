namespace Huy.Framework.Types
{
	public abstract class Error
	{
		protected Error(string message)
		{
			Message = message;
		}

		public string Message { get; }
		
	}

	public class UnExpectedError: Error
	{
		public UnExpectedError(string message) : base(message)
		{
		}
	}
}