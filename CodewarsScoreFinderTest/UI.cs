﻿using System;
namespace CodewarsScoreFinderTest
{
    public static class UI
    {
        public static void MainMenu()
        {
            User.UsersList.Clear();

            Console.WriteLine("Type the number to make a selection:\n");

            Console.WriteLine("1: Display all Class Files");
            Console.WriteLine("2: Select a Class File to show Scores");
            Console.WriteLine("3: Create a new Class File");
            Console.WriteLine("4: Edit a Class File");
            Console.WriteLine("5: Delete a Class File");
            Console.WriteLine("6: Exit");
            Console.WriteLine();

            var userInput = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (userInput)
            {
                case 1:
                    DisplayFilesMenu();
                    break;
                case 2:
                    SelectFileMenu();
                    break;
                case 3:
                    CreateFileMenu();
                    break;
                case 4:
                    ChooseFileToEditMenu();
                    break;
                case 5:
                    DeleteFileMenu();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        public static void CreateFileMenu()
        {
            CSV.CreateCSV();
        }

        public static void DeleteFileMenu()
        {
            CSV.DisplayCSVFiles();

            Console.WriteLine("Enter a filename to delete:");
            var userInput = Console.ReadLine();
            Console.WriteLine();

            CSV.DeleteCSVFile(userInput);

            Console.WriteLine("Current Class files in directory:");
            CSV.DisplayCSVFiles();
        }

        public static void DisplayFilesMenu()
        {
            CSV.DisplayCSVFiles();
        }

        public static void ChooseFileToEditMenu()
        {
            CSV.DisplayCSVFiles();

            Console.WriteLine("Enter a filename to edit:");
            var userInput = Console.ReadLine();
            Console.WriteLine();

            SwitchEditMenu(userInput);
        }

        public static void SelectFileMenu()
        {
            CSV.DisplayCSVFiles();

            Console.WriteLine("Enter a filename:");
            var userInput = Console.ReadLine();
            Console.WriteLine();

            CSV.ReadCSV(userInput);

            User.PopulateList();

            Console.WriteLine("Student Scores High to Low:\n");
            User.DisplayListHighScore();
            Console.WriteLine();
        }

        public static void SwitchEditMenu(string fileName)
        {
            var cont = true;

            do
            {
                User.UsersList.Clear();
                CSV.ReadCSV(fileName);
                CSV.DisplayUsernamesFromFile();
                Console.WriteLine();

                Console.WriteLine($"CSV File {fileName} Selected.");
                Console.WriteLine();

                Console.WriteLine("Type the number to make a selection:\n");

                Console.WriteLine("1: Add a new Username to file");
                Console.WriteLine("2: Edit a Username in file");
                Console.WriteLine("3: Delete a Username from file");
                Console.WriteLine("4: Return to Main Menu");
                Console.WriteLine();

                var userInput = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (userInput)
                {                    
                    case 1:
                        User.UsersList.Clear();
                        CSV.ReadCSV(fileName);
                        CSV.AddNewUserName();
                        var tempList = CSV.CreateUserNameListFromUsers();
                        CSV.CreateCSV(tempList, fileName);
                        break;
                    case 2:
                        User.UsersList.Clear();
                        CSV.ReadCSV(fileName);
                        CSV.UpdateUserInfo(fileName);
                        break;
                    case 3:
                        User.UsersList.Clear();
                        CSV.ReadCSV(fileName);
                        CSV.DeleteUserInCSV(fileName);
                        break;
                    case 4:
                        cont = false;
                        MainMenu();
                        break;
                    default:
                        SwitchEditMenu(fileName);
                        break;
                }
            } while (cont);
        }
    }
}

