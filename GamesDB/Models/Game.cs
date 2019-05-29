using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesDB.Models
{
	public class Game
	{
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Title { get; set; }

		[Required]
		public Developer Developer { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ReleaseDate { get; set; }

		public string Picture { get; set; }

		public int? Score { get; set; }

		public int? VoiceCounter { get; set; }

		public virtual ICollection<Genre> Genres { get; set; }
		
		public virtual ICollection<Platform> Platforms { get; set; }

		public Game()
		{
			Genres = new List<Genre>();
			Platforms = new List<Platform>();
		}
	}
}