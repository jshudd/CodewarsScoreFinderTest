using System;
namespace CodewarsScoreFinderTest
{
	public static class CSV
	{
		public static string relativeDirPath = @"ClassLists";

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

		public static void DisplayList(List<string> fileNames) => fileNames.ForEach(Console.WriteLine);

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
            var temp = "";
            var cont = true;

            while (cont)
            {
                Console.WriteLine("Enter a username.");
                temp = Console.ReadLine();

                if (temp == "")
                    Console.WriteLine("Invalid entry. Please try again.\n");
                else
                    cont = false;
            }

            return temp;
        }

		public static string PromptNewUserName()
        {
            //prompt for userName
            var temp = "";
            var cont = true;

            while (cont)
            {
                Console.WriteLine("Enter a new username.");
                temp = Console.ReadLine();

                if (temp == "")
                    Console.WriteLine("Invalid entry. Please try again.\n");
                else
                    cont = false;
            }

            return temp;
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

        public static List<string> ReadCSVTemp(string path) => File.ReadAllLines(path).ToList();

        public static List<string>? RetrieveCSVFileNames()
		{
			List<string>? fileNameList;

            string relativeFilePath = @"ClassLists";

			string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

			if (Directory.Exists(dirPath))
			{
				fileNameList = Directory.GetFiles(dirPath).ToList();
			}
			else
			{
				Console.WriteLine("CSV Folder not found.\n");
				return null;
			}

			Console.WriteLine("CSV Files Found\n");
			return fileNameList;
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
			//retrieve list of filenames in project
			var fileNameList = RetrieveCSVFileNames();

			DisplayList(fileNameList);
			Console.WriteLine();

			//prompt for csv fileName
			optFileName = PromptFileName();

			while (!VerifyValidFileName(optFileName))
			{
				Console.WriteLine("File not found. Please try again.\n");

                optFileName = PromptFileName();
            }

			var newCSVPath = $"{relativeDirPath}/{optFileName}";

            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, newCSVPath);

            //read csv file contents
            var userNames = ReadCSVTemp(dirPath);

			//display usernames
			DisplayList(userNames);

			//prompt for userName
			var search = PromptUserName();

			//find index of userName in list
			var indexNum = userNames.IndexOf(search);

			//prompt for updated userName
			var newName = PromptNewUserName();

			//update username value in static UserList
			User.UsersList[indexNum].Name = newName;

            //load updated UserList in same csv
		}

		public static bool VerifyValidFileName(string fileName)
		{
			string csvName = $"{fileName}.csv";

            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeDirPath);

			if (Directory.Exists(dirPath))
			{
				var fileNameList = Directory.GetFiles(dirPath).ToList();

				for (int i = 0; i < fileNameList.Count - 1; i++)
				{
					fileNameList[i] = Path.GetFileName(fileNameList[i]);
				}

				return !(fileNameList.Any(x => x.Equals(csvName, StringComparison.OrdinalIgnoreCase)));
			}
			else
			{
				Console.WriteLine("Folder does not exist.");

				return false;
			}
		}
	}
}