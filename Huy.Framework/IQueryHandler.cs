using Huy.Framework.Types;

namespace Huy.Framework
{
	public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
	{
		Result<TResult> Handle(TQuery query);
	}
}