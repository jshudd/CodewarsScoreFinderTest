using System;
namespace CodewarsScoreFinderTest
{
	public static class CSV
	{
		const string csvPath = "~/ClassLists/CodewarsTest.csv";

		public static void ReadCSV()
		{
            var lines = File.ReadAllLines(csvPath);

			foreach (var user in lines)
			{
				var newUser = new User();

				newUser.UserName = user;

				User.UsersList.Add(newUser);
			}
        }
	}
}

