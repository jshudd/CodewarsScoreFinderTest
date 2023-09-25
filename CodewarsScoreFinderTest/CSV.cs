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

		public static List<User> EnterUserNames()
		{
			throw new NotImplementedException();
		}

		public static void DeleteCSVFile(string fileName)
		{
			throw new NotImplementedException();
		}

		public static void DeleteUserInCSV(string userName)
		{
			//search through UserNames List to find one that matches userName
            throw new NotImplementedException();
        }

        public static void GenerateCSV(string fileName, List<User> users)
		{
			throw new NotImplementedException();
        }

        public static string PromptFileName()
        {
            //prompt for fileName
            throw new NotImplementedException();
        }

        public static string PromptUserName()
		{
			//prompt for userName
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

		public static int SelectUserFromCSV(string userName)
		{
			throw new NotImplementedException();
		}

		public static void UpdateUserInfo
			(string optFileName = "optFileName",
			string optUserName = "optUserName",
			int optIndex = 0,
			string optNewName = "optNewName")
		{
			//prompt for csv fileName
			//prompt for userName
			//find index of userName in csv file
			//prompt for updated userName
			//update username value in static UserList
			//load updated UserList in same csv
			throw new NotImplementedException();
		}
	}
}