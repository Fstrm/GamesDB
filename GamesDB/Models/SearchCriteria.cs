using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesDB.Models
{
	public abstract class SearchCriteria
	{
		public int Id { get; set; }
		
		public string Name { get; set; }

		public virtual ICollection<Game> Games { get; set; }

		public SearchCriteria()
		{
			Games = new List<Game>();
		}
	}
}