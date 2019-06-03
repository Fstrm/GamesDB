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
	public class EditController : ApiController
	{
		private GameContext db = new GameContext();

		[HttpPost]
		public void CreateGame([FromBody]Game game)
		{
			foreach (var g in game.Genres)
			{
				db.Entry(g).State = EntityState.Unchanged;
			}
			
			foreach (var p in game.Platforms)
			{
				db.Entry(p).State = EntityState.Unchanged;
			}

			db.Games.Add(game);
			db.SaveChanges();
		}
    }
}
