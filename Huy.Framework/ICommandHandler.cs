using Huy.Framework.Types;

namespace Huy.Framework
{
	
	public interface ICommandHandler<ICommand, TResult>
	{
		// Leaving TResult for database generated id
		// Beware: Command no longer executed asynchronously
		Result<TResult> Handle(ICommand command);
	}
}