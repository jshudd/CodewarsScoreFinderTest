namespace CodewarsScoreFinderTest.Tests;

public class CSVTests
{
    [Fact]
    public void CSVFileNotFound()
    {
        string relativeFilePath = @"ClassLists/C#4.csv";

        string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

        Assert.Throws<FileNotFoundException>(() => CSV.ReadCSV(csvPath));
    }

    [Fact]
    public void CreateCSVFile_SUCCESS()
    {
        var userNames = new List<string>() { "User1", "User2", "User3" };

        var fileName = "testCSV";

        // replace below call with individual methods
        CSV.CreateCSV(userNames, fileName);

        string relativeFilePath = @"ClassLists/testCSV.csv";
        string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

        Assert.True(File.Exists(csvPath));

        //DeleteCSVFile(fileName);
    }

    [Fact]
    public void DeleteCSVFile_SUCCESS()
    {
        var users = new List<string>() { "User1", "User2", "User3" };

        var fileName = "testCSV";

        CSV.CreateCSV(users, fileName);

        CSV.DeleteCSVFile(fileName);

        string relativeFilePath = @"ClassLists/testCSV.csv";
        string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

        Assert.False(File.Exists(csvPath));
    }

    [Fact]
    public void DeleteCSVFile_FAILURE()
    {
        var wrongFileName = "wrongFileName";

        Assert.Throws<FileNotFoundException>(() => CSV.DeleteCSVFile(wrongFileName));
    }

    [Fact]
    public void DeleteUserInCSV_SUCCESS()
    {
        var users = new List<string>() { "User1", "User2", "User3" };

        var fileName = "testCSV";

        CSV.CreateCSV(users, fileName);

        //hardcoding username for test
        CSV.DeleteUserInCSV("User2");

        CSV.ReadCSV(fileName);

        Assert.Equal(2, User.UsersList.Count);
        Assert.Equal("User1", User.UsersList[0].Name);
        Assert.Equal("User3", User.UsersList[1].Name);
    }

    [Fact]
    public void DeleteUserInCSV_FAILURE()
    {
        var users = new List<string>() { "User1", "User2", "User3" };

        var fileName = "testCSV";

        CSV.CreateCSV(users, fileName);

        Assert.Throws<UserNotFoundException>(() => CSV.DeleteUserInCSV("User4"));
    }

    [Fact]
    public void UpdateUserInCSV_SUCCESS()
    {
        var users = new List<string>() { "User1", "User2", "User3" };

        var fileName = "testCSV";
        var userName = "User1";
        var newName = "UserChanged";

        CSV.CreateCSV(users, fileName);

        CSV.UpdateUserInfo(fileName, userName, 0, newName);

        CSV.ReadCSV(fileName);

        Assert.Equal("UserChanged", User.UsersList[0].Name);
    }

    [Fact]
    public void VerifyValidFileName_SUCCESS()
    {
        var tempFile = "C#4000";

        var result = CSV.VerifyValidFileName(tempFile);

        Assert.True(result);
    }

    [Fact]
    public void VerifyValidFileName_FAIL()
    {
        var tempFile = "C#40";

        var result = CSV.VerifyValidFileName(tempFile);

        Assert.False(result);
    }
}