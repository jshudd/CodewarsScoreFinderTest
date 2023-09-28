﻿using System;
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

        public static void DeleteCSVFile(string fileName)
        {
            var path = $"{_dirPath}/{fileName}.csv";

            //try
            //{
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
            //}
            //catch (FileNotFoundException ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}
        }

        public static void DeleteUserInCSV(string userName)
        {
            //search through UserNames List to find one that matches userName
            throw new NotImplementedException();
        }

        public static void DisplayList(List<string> fileNames) => fileNames.ForEach(Console.WriteLine);

        //      public static void GenerateCSV(string fileName, List<User> users)
        //{
        //	throw new NotImplementedException();
        //      }

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

            //string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeDirPath);

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

        public static int SelectUserFromCSV(string userName)
        {
            throw new NotImplementedException();
        }

        public static void UpdateUserInfo
            (string optFileName = "optFileName",
            string search = "optUserName",
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

            var newCSVPath = $"{_relativeDirPath}/{optFileName}";

            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, newCSVPath);

            //read csv file contents
            var userNames = ReadCSVTemp(dirPath);

            //display usernames
            DisplayList(userNames);

            //prompt for userName
            search = PromptUserName();

            //find index of userName in list
            optIndex = userNames.IndexOf(search);

            //prompt for updated userName
            optNewName = PromptNewUserName();

            //update username value in static UserList
            User.UsersList[optIndex].Name = optNewName;

            //load updated UserList in same csv
        }

        public static bool VerifyValidFileName(string fileName)
        {
            string csvName = $"{fileName}.csv";

            //string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeDirPath);

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