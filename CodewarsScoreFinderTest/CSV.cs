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

        public static void AddNewUserName()
        {
            var userInput = PromptNewUserName();
            Console.WriteLine();

            var newUser = new User() { UserName = userInput };

            User.UsersList.Add(newUser);

            Console.WriteLine($"New Username {newUser.UserName} added to file.\n");
        }

        public static void CreateCSV(List<string>? tempList = null, string? optFileName = null)
        {
            Console.WriteLine("Creating new CSV file.\n");
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
                Console.WriteLine("Filename is already taken. Do you want to overwrite? Y or N?.");
                answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    break;
                }

                optFileName = PromptNewFileName();
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
                ? $"New csv called {optFileName} created successfully.\n"
                : "New csv file creation unsuccessful.\n");
        }

        public static List<string> EnterUserNames()
        {
            var tempUserName = "";
            var tempList = new List<string>();

            Console.WriteLine("Enter usernames or type 'exit' to stop.\n");

            while (tempUserName.ToLower() != "exit")
            {
                tempUserName = PromptUserName();

                if (tempUserName.ToLower() != "exit")
                {
                    tempList.Add(tempUserName);
                }
            }

            return tempList;
        }

        public static List<string> CreateUserNameListFromUsers()
        {
            var tempList = new List<string>();

            foreach (var user in User.UsersList)
            {
                tempList.Add(user.UserName);
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
                Console.WriteLine($"File {Path.GetFileNameWithoutExtension(path)} has been deleted successfully.\n");
            }
            else
            {
                Console.WriteLine($"File {path}.csv could not be found.\n");
                throw new FileNotFoundException();
            }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}\n");
                throw new FileNotFoundException();
            }
        }

        public static void DeleteUserInCSV(string? fileName = null, string? userName = null)
        {
            //var files = RetrieveCSVFileNames();

            //Console.WriteLine("CSV Files\n");
            //DisplayList(files);

            if (fileName == null)
            {
                fileName = PromptFileName();
            }

            var userList = ReadCSVTemp(fileName);

            Console.WriteLine("Users\n");
            DisplayList(userList);

            if (userName == null)
            {
                userName = PromptUserNameToDelete();
            }

            if (!userList.Contains(userName))
            {
                Console.WriteLine("Username not found.");
                throw new UserNotFoundException();
            }
            
            userList.Remove(userName);

            CreateCSV(userList, fileName);
        }

        public static void DisplayCSVFiles()
        {
            var fileList = RetrieveCSVFileNames();

            for (int i = 0; i < fileList.Count; i++)
            {
                Console.WriteLine($"{i+1}: {fileList[i]}");
            }
            Console.WriteLine();
        }

        public static void DisplayList(List<string> fileNames) => fileNames.ForEach(Console.WriteLine);

        public static void DisplayUsernamesFromFile() => User.UsersList.ForEach(x => Console.WriteLine(x.UserName));

        public static string PromptFileName()
        {
            var temp = "";
            var cont = true;

            while (cont)
            {
                Console.WriteLine("Enter a Filename for csv file.");
                temp = Console.ReadLine();

                if (temp == "")
                    Console.WriteLine("Invalid entry. Please try again.\n");
                else
                    cont = false;
            }

            return temp;
        }

        public static string PromptNewFileName()
        {
            var temp = "";
            var cont = true;

            while (cont)
            {
                Console.WriteLine("Enter a New Filename for csv file.");
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
                Console.WriteLine("Enter a Username.");
                temp = Console.ReadLine();

                if (temp == "")
                    Console.WriteLine("Invalid entry. Please try again.\n");
                else
                    cont = false;
            }

            return temp;
        }

        public static string PromptUserNameToDelete()
        {
            var temp = "";
            var cont = true;

            while (cont)
            {
                Console.WriteLine("Enter a Username to Delete.");
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

                for (int i = 0; i < fileNameList.Count; i++)
                {
                    fileNameList[i] = Path.GetFileNameWithoutExtension(fileNameList[i]);
                }

                fileNameList.RemoveAt(0);
                //.DS_Store
            }
            else
            {
                Console.WriteLine("CSV Folder not found.\n");
                return null;
            }

            Console.WriteLine($"{fileNameList.Count} CSV Files Found\n");

            //for (int i = 0; i < fileNameList.Count; i++)
            //{
            //    fileNameList[i] = Path.GetFileNameWithoutExtension(fileNameList[i]);
            //}

            return fileNameList;
        }

        //public static int SelectUserFromCSV(List<string> userList)
        //{
        //    throw new NotImplementedException();
        //}

        public static void UpdateUserInfo
            (string fileName = "optFileName",
            string search = "optUserName",
            string newName = "optNewName")
        {
            if (fileName == "optFileName")
                fileName = PromptFileName();

            while (!VerifyValidFileName(fileName))
            {
                Console.WriteLine("File not found. Please try again.\n");

                fileName = PromptFileName();
            }

            var userNames = ReadCSVTemp(fileName);

            if (search == "optUserName")
            {
                DisplayList(userNames);

                search = PromptUserName();
            }

            var index = userNames.IndexOf(search);

            if (newName == "optNewName")
                newName = PromptNewUserName();

            try
            {
                User.UsersList[index].UserName = newName;
                Console.WriteLine("Username updated.\n");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Username {search} not found.\n");
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