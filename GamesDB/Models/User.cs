using System.ComponentModel.DataAnnotations;

namespace GamesDB.Models
{
	public class User : IUser
	{
		public int Id { get; set; }

		public string Token { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Username { get; set; }

		[Required(AllowEmptyStrings = false)]
		public string Password { get; set; }
	}
}