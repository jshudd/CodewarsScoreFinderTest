namespace CodewarsScoreFinderTest.Tests;

public class CSVTests
{
    [Fact]
    public void CSVFileNotFound()
    {
        string relativeFilePath = @"ClassLists/C#4.csv";

        string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

        Assert.Throws<DirectoryNotFoundException>(() => CSV.ReadCSV(csvPath));
    }

    [Fact]
    public void CreateCSVFile_SUCCESS()
    {
        var userNames = new List<User>()
        {
            new User { UserName = "User1"},
            new User { UserName = "User2"},
            new User { UserName = "User3"}
        };

        // replace below call with individual methods
        CSV.CreateCSV();

        string relativeFilePath = @"ClassLists/test.csv";
        string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

        //Assert.NotNull(csvPath);
        Assert.True(File.Exists(csvPath));
    }

    [Fact]
    public void DeleteCSVFile_SUCCESS()
    {
        var users = new List<User>()
        {
            new User { UserName = "User1"},
            new User { UserName = "User2"},
            new User { UserName = "User3"}
        };

        var fileName = "testCSV";

        CSV.GenerateCSV(fileName, users);

        CSV.DeleteCSVFile(fileName);

        string relativeFilePath = @"ClassLists/testCSV.csv";
        string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

        Assert.False(File.Exists(csvPath));
    }

    [Fact]
    public void DeleteUserInCSV_SUCCESS()
    {
        var userNames = new List<User>()
        {
            new User { UserName = "User1"},
            new User { UserName = "User2"},
            new User { UserName = "User3"}
        };

        //hardcoding username for test
        CSV.DeleteUserInCSV("User2");

        Assert.Equal(2, userNames.Count);
        Assert.Equal("User1", userNames[0].Name);
        Assert.Equal("User3", userNames[1].Name);
    }
}