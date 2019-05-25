using System.ComponentModel.DataAnnotations;

namespace GamesDB.Models
{
	public class User
	{
		public int Id { get; set; }

		public string Token { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Username { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Password { get; set; }

		public bool IsAdmin { get; set; }
	}
}