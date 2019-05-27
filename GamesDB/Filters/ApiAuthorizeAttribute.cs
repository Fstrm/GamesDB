using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using GamesDB.Validators;

namespace GamesDB.Filters
{
	public class ApiAuthorizeAttribute : Attribute, System.Web.Http.Filters.IAuthorizationFilter
	{
		public bool AllowMultiple => false;

		public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
		{
			string token = actionContext.Request.Headers.GetValues("Auth").FirstOrDefault();
			Validator val = new UserValidator(token);
			if (val.IsCorrect())
			{
				return continuation();
			}
			return Task.FromResult(actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized));
		}
	}
}