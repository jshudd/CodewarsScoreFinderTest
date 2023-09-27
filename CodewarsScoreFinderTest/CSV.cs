using System;
namespace CodewarsScoreFinderTest
{
	public static class CSV
	{
		public static void CreateCSV(List<User> optUsers = null, string optFileName = "optFileName")
		{
            //call method to ask user to enter usernames; store in variable
			//call method to create filename for new file
            //call method to generate CSV file

            throw new NotImplementedException();
		}

		public static List<string> EnterUserNames()
		{
			var tempUserName = "";
			var tempList = new List<string>();

			while(tempUserName != "EXIT")
			{
				Console.WriteLine("Enter a username or type EXIT (all caps) to exit.\n");
				tempUserName = Console.ReadLine();

				if(tempUserName != "EXIT" || tempUserName != "")
					tempList.Add(tempUserName);
			}

			return tempList;
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
			var temp = "";
			var cont = true;

			while (cont)
			{
				Console.WriteLine("Enter a filename.");
				temp = Console.ReadLine();

				if (temp == "")
                    Console.WriteLine("Invalid entry. Please try again.\n");
				else
					cont = false;
			}

			return temp;
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
			//print list of filenames in project
			//prompt for csv fileName
			//prompt for userName
			//find index of userName in csv file
			//prompt for updated userName
			//update username value in static UserList
			//load updated UserList in same csv
			throw new NotImplementedException();
		}

		public static bool VerifyValidFileName(string fileName)
		{
            string relativeFilePath = @"ClassLists";

            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

			if (Directory.Exists(dirPath))
			{
				var fileNameList = Directory.GetFiles(dirPath).ToList();

				return (!fileNameList.Any(x => x.Equals(fileName, StringComparison.OrdinalIgnoreCase)));
			}

			return false;

			//else
			//{
			//	Console.WriteLine("Folder does not exist.");

			//	return false;
			//}
        }
	}
}