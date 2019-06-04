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
			context.Genres.Add(new Genre { Name = "Strategy" });
			context.Genres.Add(new Genre { Name = "Platform" });
			context.Genres.Add(new Genre { Name = "Shooter" });
			context.Genres.Add(new Genre { Name = "RPG"});
			context.Genres.Add(new Genre { Name = "Adventure" });
			context.Genres.Add(new Genre { Name = "Racing" });

			context.Platforms.Add(new Platform { Name = "PC" });
			context.Platforms.Add(new Platform { Name = "Playstation" });
			context.Platforms.Add(new Platform { Name = "Xbox" });

			context.Users.Add(new User { Username = "kekus", Password = "a", Token = Token.CreateNew(), IsAdmin = true });

			base.Seed(context);
		}
	}
}