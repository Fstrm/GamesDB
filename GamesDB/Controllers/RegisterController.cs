using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GamesDB.Models;

namespace GamesDB.Controllers
{
    public class RegisterController : ApiController
    {
		private GameContext db = new GameContext();
		
		public string GetToken(string username, string password)
		{
			if (!(String.IsNullOrEmpty(username) && username.All(char.IsDigit)) && !String.IsNullOrEmpty(password))
			{
				if (!db.Users.Any(u => u.Username == username))
				{
					User user = new User
					{
						Username = username,
						Password = password,
						Token = Token.CreateNew(),
						IsAdmin = Request.IsLocal() && db.Users.Count() == 0
					};

					db.Users.Add(user);
					db.SaveChanges();
					db.Dispose();

					return user.Token;
				}
			}

			return null;
		}

		[Route("api/Login")]
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
