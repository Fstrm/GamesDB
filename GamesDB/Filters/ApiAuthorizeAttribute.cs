using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace GamesDB.Filters
{
	public class ApiAuthorizeAttribute : Attribute, IAuthorizationFilter
	{
		public bool AllowMultiple => false;

		public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
		{
			string token = actionContext.Request.Headers.GetValues("Authorization").FirstOrDefault();
			Models.Validator val = new Models.Validator(token);
			if (val.IsCorrect())
			{
				return continuation();
			}
			return Task.FromResult(actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized));
		}
	}
}