using CodewarsScoreFinderTest;

Console.WriteLine("Codewars Score Finder\n");

string relativeFilePath = @"ClassLists/C#40.csv";
//string relativeFilePath = @"ClassLists/CodewarsTest.csv";

string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

CSV.ReadCSV(csvPath);

User.PopulateList();

//User.DisplayList();

Console.WriteLine("Score in Descending Order");

User.DisplayListHighScore();