using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Huy.Framework.DependencyInjection
{
	public class ControllerActivator: IControllerActivator
	{
		

		public ControllerActivator()
		{
			// instantiate dependencies here
		}
		
		public object Create(ControllerContext context)
		{
			Type type = context.ActionDescriptor.ControllerTypeInfo.AsType();
			// DI Func through here
			return Activator.CreateInstance(type);
		}

		public void Release(ControllerContext context,
			object controller)
		{
			
		}
	}

	
}