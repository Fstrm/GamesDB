using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GamesDB.Models
{
	public class GameContext : DbContext
	{
		public GameContext() : base()
		{
			Database.SetInitializer(new DbInitializer());
		}

		public DbSet<Game> Games { get; set; }
		public DbSet<Developer> Developers { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Platform> Platforms { get; set; }
		public DbSet<User> Users { get; set; }
	}
}