using System;
using System.Linq;

namespace GamesDB.Validators
{
	public abstract class Validator
	{
		protected string _token;

		public Validator(string token)
		{
			_token = token;
		}

		public virtual bool IsCorrect()
		{
			if (!String.IsNullOrEmpty(_token))
			{
				using (Models.GameContext db = new Models.GameContext())
				{
					return db.Users.Any(u => u.Token == _token);
				}
			}
			return false;
		}
	}
}