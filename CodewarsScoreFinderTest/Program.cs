using CodewarsScoreFinderTest;

Console.WriteLine("Codewars Score Finder\n");

// testing reading CSV file
string relativeFilePath = @"ClassLists/CodewarsTest.csv";

string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

CSV.ReadCSV(csvPath);

//foreach (var user in User.UsersList)
//{
//    user.JSON = API.CallAPI(user.UserName);
//    user.ParseJSON();
//}

User.PopulateList();

foreach (var user in User.UsersList)
{
    Console.WriteLine($"{user.Name}, {user.UserName}, {user.Honor}");
}