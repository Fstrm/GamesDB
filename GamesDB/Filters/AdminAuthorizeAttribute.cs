using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using GamesDB.Validators;

namespace GamesDB.Filters
{
	public class AdminAuthorizeAttribute : Attribute, System.Web.Http.Filters.IAuthorizationFilter
	{
		public bool AllowMultiple => false;

		public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
		{
			string token = actionContext.Request.Headers.GetValues("Auth").FirstOrDefault();
		}
	}
}