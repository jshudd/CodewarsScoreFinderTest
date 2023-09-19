using CodewarsScoreFinderTest;

Console.WriteLine("Codewars Score Finder\n");
Console.WriteLine();

// testing reading CSV file
string relativeFilePath = @"ClassLists/CodewarsTest.csv";

string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

CSV.ReadCSV(csvPath);

foreach (var user in User.UsersList)
{
    Console.WriteLine(user.UserName);
}