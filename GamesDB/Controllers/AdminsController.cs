using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesDB.Models;

namespace GamesDB.Controllers
{
    public class AdminsController : Controller
    {
		private GameContext db = new GameContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}