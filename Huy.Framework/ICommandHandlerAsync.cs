using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework
{
	public interface ICommandHandlerAsync<ICommand, TResult>
	{
		// Leaving TResult for database generated id
		// Beware: Command no longer executed asynchronously
		public Result<Task<TResult>> HandleAsync(ICommand command);
	}
}