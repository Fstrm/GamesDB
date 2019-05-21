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

		public string GetToken(string login, string password)
		{
			if (!(String.IsNullOrEmpty(login) && login.All(char.IsDigit)) && !String.IsNullOrEmpty(password))
			{
				if (!db.Users.Any(u => u.Username == login))
				{
					User user = new User
					{
						Username = login,
						Password = password,
						Token = Token.CreateNew()
					};

					db.Users.Add(user);
					db.SaveChanges();
					db.Dispose();

					return user.Token;
				}
			}

			return null;
		}
    }
}
