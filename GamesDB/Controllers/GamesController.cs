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
		private List<string> options = new List<string>
		{
			"-Sort-by-",
			"Recent",
			"Name"
		};


		public ActionResult Index()
		{
			ViewBag.Options = new SelectList(options);
			return View(db.Games.Include("Developer").ToList());
		}

		public ActionResult GamesBlock(string filter)
		{
			IEnumerable<Game> filteredSet = db.Games.Include("Developer");
			
			if (filter == "Recent")
			{
				filteredSet = filteredSet.OrderBy(g => g.ReleaseDate);
			}
			else if (filter == "Name")
			{
				filteredSet = filteredSet.OrderBy(g => g.Title);
			}

			return PartialView(filteredSet.ToList());
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