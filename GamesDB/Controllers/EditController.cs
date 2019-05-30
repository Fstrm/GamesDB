using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GamesDB.Models;
namespace GamesDB.Controllers
{
    public class EditController : ApiController
    {
		private GameContext db = new GameContext();

		[HttpPost]
		public void CreateGame([FromBody]Game game)
		{
			db.Games.Add(game);
			db.SaveChanges();
		}
    }
}
