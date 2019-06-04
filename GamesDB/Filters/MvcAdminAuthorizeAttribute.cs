using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using GamesDB.Validators;

namespace GamesDB.Filters
{
	public class MvcAdminAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (!filterContext.HttpContext.Request.IsLocal)
			{
				filterContext.Result = new HttpUnauthorizedResult();
			}
		}
	}
}