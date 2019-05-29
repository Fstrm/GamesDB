using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GamesDB.Models
{
	public class DbInitializer : DropCreateDatabaseAlways<GameContext> 
	{
		protected override void Seed(GameContext context)
		{
			context.Genres.Add(new Genre { Name = "Action" });
			context.Genres.Add(new Genre { Name = "Shooter" });
			context.Genres.Add(new Genre { Name = "RPG"});

			context.Platforms.Add(new Platform { Name = "PC" });
			context.Platforms.Add(new Platform { Name = "Playstation" });
			context.Platforms.Add(new Platform { Name = "Xbox" });
			
			base.Seed(context);
		}
	}
}