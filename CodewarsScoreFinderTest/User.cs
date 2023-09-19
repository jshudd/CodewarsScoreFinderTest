using System;
namespace CodewarsScoreFinderTest
{
	public class User
	{
		public User()
		{
		}

		public string UserName { get; set; }
		public string Name { get; set; }
		public int Honor { get; set; }
		public string JSON { get; set; }

		public static List<User> UsersList { get; set; } = new List<User>();
	}
}

