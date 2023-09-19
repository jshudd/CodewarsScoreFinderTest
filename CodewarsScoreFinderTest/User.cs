using System;
using Newtonsoft.Json.Linq;

namespace CodewarsScoreFinderTest
{
	public class User
	{
		public User()
		{
		}

		public string UserName { get; set; }
		public string Name { get; set; }
		public string Honor { get; set; }
		public string JSON { get; set; }

		public static List<User> UsersList { get; set; } = new List<User>();

		public void ParseJSON()
		{
			Name = JObject.Parse(JSON).GetValue("name").ToString();

            Honor = JObject.Parse(JSON).GetValue("honor").ToString();
        }

		public static void PopulateList()
		{
            foreach (var user in UsersList)
            {
                JSON = API.CallAPI(user.UserName);
                ParseJSON();
            }
        }
	}
}

