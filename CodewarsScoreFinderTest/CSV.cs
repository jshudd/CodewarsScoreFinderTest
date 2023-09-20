using System;
namespace CodewarsScoreFinderTest
{
	public static class CSV
	{
		public static void CreateCSV()
		{
			//call method to create filename for new file
			//call method to ask user to enter usernames

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

