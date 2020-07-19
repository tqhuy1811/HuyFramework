using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework
{
	public interface IQueryProcessorAsync
	{
		// For when there's too many query handler inside controller constructor
		Result<Task<TResult>> Process<TResult>(IQuery<TResult> query);
	}
}