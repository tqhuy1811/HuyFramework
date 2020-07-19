using System.Threading.Tasks;
using Huy.Framework.Types;

namespace Huy.Framework
{
	public interface IQueryHandlerAsync<TQuery, TResult> where TQuery : IQuery<TResult>
	{
		Result<Task<TResult>> Handle(TQuery query);
	}
}