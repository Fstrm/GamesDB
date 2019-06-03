using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GamesDB.Models;
using System.Data.Entity;

namespace GamesDB.Controllers
{
    public class UserController : ApiController
    {
		[HttpPut]
		public int? InsertUserMark(int gameId, string user, int userScore)
		{
			using (GameContext db = new GameContext())
			{
				Mark userMark = db.Marks.FirstOrDefault(m => m.GameId == gameId && m.User.Username == user);
				if (userMark != null)
				{
					userMark.Score = userScore;
					db.Entry(userMark).State = EntityState.Modified;
				}
				else
				{
					userMark = new Mark { GameId = gameId, User = db.Users.FirstOrDefault(u => u.Username == user), Score = userScore };
				}
					 
				Game rated = db.Games.Include("Developer").Where(g => g.Id == gameId).FirstOrDefault();
				if (rated != null)
				{
					rated.VoiceCounter++;
					rated.Score += (userScore - rated.Score) / rated.VoiceCounter;
					db.Entry(rated).State = EntityState.Modified;
				}

				db.Marks.Add(userMark);
				db.SaveChanges();
				return rated.Score;
			}
		}
    }
}
