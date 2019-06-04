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
			return View(db.Games.Include("Developer").ToList());
		}

		public ActionResult Subject(int? id)
		{
			if (id == null)
			{
				return RedirectToAction("Index");
			}

			Game game = db.Games.Find(id);
			db.Entry(game).Reference("Developer").Load();

			if (game == null)
			{
				return HttpNotFound();
			}

			return View(game);
		}

		public ActionResult Search(string name)
		{
			var games = db.Games.Where(g => g.Title.Contains(name));
			return View(games);
		}
	}
}