using System;
namespace CodewarsScoreFinderTest
{
	public static class CSV
	{
		public static void CreateCSV()
		{
            //call method to ask user to enter usernames
			//call method to create filename for new file
            //call method to generate CSV file

            throw new NotImplementedException();
		}

		public static string EnterFileName()
		{
			throw new NotImplementedException();
		}

		public static List<User> EnterUserNames()
		{
			throw new NotImplementedException();
		}

		public static void DeleteCSVFile()
		{
			throw new NotImplementedException();
		}

		public static void DeleteUserInCSV()
		{
            throw new NotImplementedException();
        }

        public static void GenerateCSV(string fileName, List<User> users)
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

