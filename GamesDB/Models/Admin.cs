using System;

namespace GamesDB.Models
{
	public class Admin : IUser
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Token { get; set; }
	}
}