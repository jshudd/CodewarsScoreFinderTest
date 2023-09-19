using System;
namespace CodewarsScoreFinderTest
{
	public class Users
	{
		public Users()
		{
		}

		public string UserName { get; set; }
		public string Name { get; set; }
		public int Honor { get; set; }
		public string JSON { get; set; }

		public static List<Users> UsersList { get; set; } = new List<Users>();
	}
}

