using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesDB.Models
{
	public class Token
	{
		public static string CreateNew()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			for(int i = 0; i < sizeof(int); i++)
			{
				sb.Append(Guid.NewGuid().ToString().Replace("-", ""));
			}
			return sb.ToString();
		}
	}
}