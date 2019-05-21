using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesDB.Models
{
	public interface IUser
	{
		int Id { get; set; }
		string Token { get;set; }
	}
}