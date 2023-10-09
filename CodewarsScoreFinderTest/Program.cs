using CodewarsScoreFinderTest;

//string relativeFilePath = @"ClassLists/C#40.csv";
////string relativeFilePath = @"ClassLists/CodewarsTest.csv";

//string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

//CSV.ReadCSV(csvPath);

//User.PopulateList();

////User.DisplayList();

//Console.WriteLine("Score in Descending Order");

//User.DisplayListHighScore();

// New Implementation

// Set Console Title
Console.Title = "Codewars Score Finder";
// Set Background Color
Console.BackgroundColor = ConsoleColor.Black;
// Set Text Color
Console.ForegroundColor = ConsoleColor.White;
// Set Window Position (not suported on Mac)
//Console.SetWindowPosition(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2);
// Set Window Size (not suported on Mac)
//Console.SetWindowSize(500, 500);

var isTrue = true;

Console.WriteLine("Codewars Score Finder\n");

do
{
    UI.MainMenu();

} while (isTrue);