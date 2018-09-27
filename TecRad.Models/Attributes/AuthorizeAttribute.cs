using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TecRad.Models.Attributes
{
	public class AuthorizeAttribute : ActionFilterAttribute
	{
		String magicString = "efuyjurfkyisdgekrugxkmetdirkwldtnifkrnyiklgldix";

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var header = context.HttpContext.Request.Headers["Authorization"];
			if (header != magicString)
			{
				context.Result = new UnauthorizedResult();
			}
		}
	}
}