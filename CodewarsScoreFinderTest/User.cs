using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace CodewarsScoreFinderTest
{
	public class User
	{
		public User()
		{
		}

		public string? UserName { get; set; }
		public string? Name { get; set; }
		public int? Honor { get; set; }
		public string? JSON { get; set; }

		public static List<User> UsersList { get; set; } = new List<User>();

		public static void DisplayList()
		{
            foreach (var user in UsersList)
            {
                Console.WriteLine(user.ToString());
            }
        }

		public static void DisplayListHighScore()
		{
			var scoreDescList = UsersList.OrderByDescending(x => x.Honor).ToList();

			scoreDescList.ForEach(Console.WriteLine);
		}

		public void ParseJSON()
		{
			try
			{
				Name = JObject.Parse(JSON).GetValue("name").ToString();
			}
			catch (Newtonsoft.Json.JsonException)
			{
				Console.WriteLine($"No \"name\" value in JSON file");
				throw new Newtonsoft.Json.JsonException();
			}

			if (Name == "")
				Name = "Not Listed";

            Honor = int.Parse(JObject.Parse(JSON).GetValue("honor").ToString());
        }

		public static void PopulateList()
		{
            foreach (var user in UsersList)
            {
                user.JSON = API.CallAPI(user.UserName);
                user.ParseJSON();
            }
        }

		public override string ToString()
		{
			return $"{Name}, {UserName}, {Honor}";
        }
	}
}

