using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GamesDB.Controllers
{
    public class LoginController : ApiController
    {
		private Models.GameContext db = new Models.GameContext();

		public string GetUserToken(string login, string password)
		{
			if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
			{
				return db.Users.FirstOrDefault(u => u.Username == login && u.Password == password)?.Token;
			}
			return null;
		}
    }
}
