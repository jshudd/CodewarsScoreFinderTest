using System;
namespace CodewarsScoreFinderTest
{
	public static class CSV
	{
		public static void CreateCSV(List<User> users)
		{
			throw new NotImplementedException();
		}

		public static void ReadCSV(string path)
		{            
            var lines = File.ReadAllLines(path);

			foreach (var user in lines)
			{
                var newUser = new User
                {
                    UserName = user
                };

                User.UsersList.Add(newUser);
			}
        }
	}
}

