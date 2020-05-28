using System;
using System.Collections.Generic;
using System.Data;
using Huy.Framework.Types;
using static Huy.Framework.Types.UnitExt;
using Unit = Huy.Framework.Types.Unit;


namespace Huy.Framework.DependencyInjection
{
	public class Dispatcher<TMessage, TResult>
	{
		private readonly Dictionary<Type, Func<TMessage, TResult>> _dictionary = new Dictionary<Type, Func<TMessage, TResult>>();

		public void Register<T>(Func<T, TResult> func) where T : TMessage
		{
			_dictionary.Add(typeof(T), x => func((T)x));
		}

		public TResult Dispatch(TMessage m)
		{
			if (!_dictionary.TryGetValue(m.GetType(), out var handler))
			{
				throw new Exception("cannot map " + m.GetType());
			}
			return handler(m);
		}
	}


	public class Input : ICommand
	{
		
	}


	public static class CommandHandlers
	{
		public static Result<Unit> BusinessLogicA(Func<IDbConnection> connection, Input input)
		{
			Console.WriteLine("Do business logic");
			return Result<Unit>.Ok(Unit());
		}  
	}

	public class Program
	{ 
		private static Dispatcher<ICommand, Result<Unit>> _dispatcher;
		public static void Initialize()
		{
			_dispatcher = new Dispatcher<ICommand, Result<Unit>>();
			
			// Scoped
			_dispatcher.Register<Input>(
				message =>
				{
					var connection = new Func<IDbConnection>(default);
					return CommandHandlers.BusinessLogicA(connection, message);
				});
			
			// Singleton
			var connection = new Func<IDbConnection>(default);
			
			_dispatcher.Register<Input>(
				message => CommandHandlers.BusinessLogicA(connection, message));
			
			// Transient
			_dispatcher.Register<Input>(
				message => CommandHandlers.BusinessLogicA(new Func<IDbConnection>(default), message));
			
		}

		public static void Main(string[] args)
		{
			Initialize();
			_dispatcher.Dispatch(new Input());
		}
	}
	

}