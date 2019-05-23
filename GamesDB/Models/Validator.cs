using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesDB.Models
{
	public class Validator
	{
		private string _token;

		public Validator(string token)
		{
			_token = token;
		}

		public bool IsCorrect()
		{
			if (!String.IsNullOrEmpty(_token))
			{
				using (GameContext db = new GameContext())
				{
					return db.Users.Any(u => u.Token == _token);
				}
			}
			return false;
		}
	}
}