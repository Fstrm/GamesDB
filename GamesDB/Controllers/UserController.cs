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
		[Filters.ApiAuthorize]
		public int? InsertUserMark(int gameId, string user, int userScore)
		{
			using (GameContext db = new GameContext())
			{
				Mark userMark = db.Marks.FirstOrDefault(m => m.GameId == gameId && m.User.Username == user);
				bool exists;
				if (userMark != null)
				{
					userMark.Score = userScore;
					db.Entry(userMark).State = EntityState.Modified;
					exists = true;
				}
				else
				{
					userMark = new Mark { GameId = gameId, User = db.Users.FirstOrDefault(u => u.Username == user), Score = userScore };
					exists = false;
				}
					 
				Game rated = db.Games.Include("Developer").Where(g => g.Id == gameId).FirstOrDefault();
				if (rated != null)
				{
					if (!exists)
						rated.VoiceCounter++;
					rated.Score += (userScore - rated.Score) / rated.VoiceCounter;
					db.Entry(rated).State = EntityState.Modified;
				}

				db.Marks.Add(userMark);
				db.SaveChanges();
				return rated.Score;
			}
		}

		[HttpGet]
		public IEnumerable<Game> FindGames(string keyword)
		{
			using (GameContext db = new GameContext())
			{
				var games = db.Games.Where(g => g.Title.Contains(keyword));
				return games;
			}
		}
    }
}
