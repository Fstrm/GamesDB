using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesDB.Models;
using GamesDB.Filters;

namespace GamesDB.Controllers
{
	public class GamesController : Controller
	{
		private GameContext db = new GameContext();
		
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Game(int? id)
		{
			if (id == null)
			{
				return RedirectToAction("Index");
			}

			Game game = db.Games.Find(id);

			if (game == null)
			{
				return HttpNotFound();
			}
			return View(game);
		}
	}
}