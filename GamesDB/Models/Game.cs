using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamesDB.Models
{
	public class Game
	{
		[Key]
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Title { get; set; }

		[Required]
		public Developer Developer { get; set; }
		
		[Required(AllowEmptyStrings = false)]
		public DateTime ReleaseDate { get; set; }

		public string Picture { get; set; }

		public int Score { get; set; } = 0;

		public int VoiceCounter { get; set; } = 0;
		
		public virtual ICollection<Genre> Genres { get; set; }
		
		public virtual ICollection<Platform> Platforms { get; set; }

		public Game()
		{
			Genres = new List<Genre>();
			Platforms = new List<Platform>();
		}
	}
}