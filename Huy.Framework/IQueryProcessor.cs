using Huy.Framework.Types;

namespace Huy.Framework
{
	public interface IQueryProcessor
	{
		// For when there's too many query handler inside controller constructor
		Result<TResult> Process<TResult>(IQuery<TResult> query);
	}
}