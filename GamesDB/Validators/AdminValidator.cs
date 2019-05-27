using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamesDB.Validators;

namespace GamesDB.Validators
{
	public class AdminValidator : Validator
	{
		public AdminValidator(string token) : base(token)
		{
		}

		public override bool IsCorrect()
		{
			if (!String.IsNullOrEmpty(_token))
			{
				using (Models.GameContext db = new Models.GameContext())
				{
					return db.Users.Any(u => u.Token == _token && u.IsAdmin);
				}
			}
			return false;
		}
	}
}