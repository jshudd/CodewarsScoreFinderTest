using System;
using System.Globalization;
using System.Text;
using CsvHelper;

namespace CodewarsScoreFinderTest
{
    public static class CSV
    {
        private static string _relativeDirPath = @"ClassLists";
        private static string _dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativeDirPath);

        public static void CreateCSV(List<string>? tempList = null, string? optFileName = null)
        {
            var answer = "";

            if (tempList == null)
            {
                tempList = EnterUserNames();
            }

            if (optFileName == null)
            {
                optFileName = PromptFileName();
            }

            while (!VerifyValidFileName(optFileName))
            {
                Console.WriteLine("Filename is already taken. Do you want to overwrite? Y or N?.\n");
                answer = Console.ReadLine();

                if (answer.ToLower() == "n")
                {
                    break;
                }

                optFileName = PromptFileName();
            }

            var filePath = $"{_dirPath}/{optFileName}.csv";

            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach (var name in tempList)
                {
                    writer.WriteLine($"{name},");
                }
            }

            Console.WriteLine((!VerifyValidFileName(optFileName))
                ? $"New csv called {optFileName} created successfully."
                : "New csv file creation unsuccessful");
        }

        public static List<string> EnterUserNames()
        {
            var tempUserName = "";
            var tempList = new List<string>();

            while (tempUserName != "EXIT")
            {
                Console.WriteLine("Enter multiple usernames or type EXIT (all caps) to exit.\n");
                tempUserName = Console.ReadLine();

                if (tempUserName != "EXIT" || tempUserName != "")
                    tempList.Add(tempUserName);
            }

            return tempList;
        }

        public static List<string> CreateUserNameListFromUsers()
        {
            var tempList = new List<string>();

            foreach (var user in User.UsersList)
            {
                tempList.Add(user.Name);
            }

            return tempList;
        }

        public static void DeleteCSVFile(string fileName)
        {
            var path = $"{_dirPath}/{fileName}.csv";

            try
            {
                if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine($"File {path}.csv has been deleted successfully.");
            }
            else
            {
                Console.WriteLine($"File {path}.csv could not be found.");
                throw new FileNotFoundException();
            }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new FileNotFoundException();
            }
        }

        public static void DeleteUserInCSV(string? fileName = null, string? userName = null)
        {
            //display all csv files
            var files = RetrieveCSVFileNames();

            Console.WriteLine("CSV Files\n");
            DisplayList(files);

            //user selects csv file
            if (fileName == null)
            {
                fileName = PromptFileName();
            }

            //add all usernames to list
            var userList = ReadCSVTemp(fileName);

            //display all usernames
            Console.WriteLine("Users\n");
            DisplayList(userList);

            //app user selects user to delete from file
            if (userName == null)
            {
                userName = Console.ReadLine();
            }

            //get index of userName
            //var indexNum = userList.IndexOf(userName);

            //remove user from list
            //userList.RemoveAt(indexNum - 1);
            if (!userList.Contains(userName))
            {
                throw new UserNotFoundException();
            }
            
            userList.Remove(userName);

            CreateCSV(userList, fileName);
        }

        public static void DisplayList(List<string> fileNames) => fileNames.ForEach(Console.WriteLine);

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
            //var newCSVPath = $"{_relativeDirPath}/{path}";
            var newCSVPath = $"{_relativeDirPath}/{path}.csv";

            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, newCSVPath);

            var lines = File.ReadAllLines(dirPath).ToList();

            lines = RemoveCommas(lines);

            foreach (var user in lines)
            {
                var newUser = new User
                {
                    UserName = user
                };

                User.UsersList.Add(newUser);
            }
        }

        public static List<string> ReadCSVTemp(string path)
        {
            var newCSVPath = $"{_relativeDirPath}/{path}.csv";

            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, newCSVPath);

            var list = new List<string>();

            try
            {
                list = File.ReadAllLines(dirPath).ToList();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {path} not found.");
                throw new FileNotFoundException();
            }

            //for (int i = 0; i < list.Count; i++)
            //{
            //    list[i] = list[i].TrimEnd(',');
            //}

            //return list;

            return RemoveCommas(list);
        }

        public static List<string> RemoveCommas(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].TrimEnd(',');
            }

            return list;
        }

        public static List<string>? RetrieveCSVFileNames()
        {
            List<string>? fileNameList;

            if (Directory.Exists(_dirPath))
            {
                fileNameList = Directory.GetFiles(_dirPath).ToList();
            }
            else
            {
                Console.WriteLine("CSV Folder not found.\n");
                return null;
            }

            Console.WriteLine("CSV Files Found\n");
            return fileNameList;
        }

        public static int SelectUserFromCSV(List<string> userList)
        {
            throw new NotImplementedException();
        }

        public static void UpdateUserInfo
            (string fileName = "optFileName",
            string search = "optUserName",
            string newName = "optNewName")
        {
            var fileNameList = RetrieveCSVFileNames();

            DisplayList(fileNameList);
            Console.WriteLine();


            if (fileName == "optFileName")
                fileName = PromptFileName();

            while (!VerifyValidFileName(fileName))
            {
                Console.WriteLine("File not found. Please try again.\n");

                fileName = PromptFileName();
            }

            var userNames = ReadCSVTemp(fileName);

            DisplayList(userNames);

            if (search == "optUserName")
                search = PromptUserName();

            var index = userNames.IndexOf(search);

            if (newName == "optNewName")
                newName = PromptNewUserName();

            try
            {
                User.UsersList[index].Name = newName;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"User Name {search} not found.");
                throw new ArgumentOutOfRangeException();
            }

            var tempList = CreateUserNameListFromUsers();

            CreateCSV(tempList, fileName);
        }

        public static bool VerifyValidFileName(string fileName)
        {
            string csvName = $"{fileName}.csv";

            if (Directory.Exists(_dirPath))
            {
                var fileNameList = Directory.GetFiles(_dirPath).ToList();

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