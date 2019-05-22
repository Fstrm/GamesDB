using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamesDB.Models
{
	public class Mark
	{
		[Key, Column(Order = 1)]
		public int GameId { get; set; }

		[Range(0, 10)]
		public int Score { get; set; }

		public virtual User User { get; set; }

		public virtual Game Game { get; set; }
	}
}