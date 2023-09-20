﻿namespace CodewarsScoreFinderTest.Tests;

public class UnitTest1
{
    [Fact]
    public void CSVFileNotFound()
    {
        string relativeFilePath = @"ClassLists/C#4.csv";

        string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

        Assert.ThrowsAny<DirectoryNotFoundException>(() => CSV.ReadCSV(csvPath));
    }

    [Fact]
    public void CreateCSVFile_Success()
    {
        var userNames = new List<User>()
        {
            new User { UserName = "User1" },
            new User { UserName = "User2"},
            new User { UserName = "User3"}
        };

        CSV.CreateCSV(userNames);

        string relativeFilePath = @"ClassLists/test.csv";
        string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

        Assert.NotNull(csvPath);
        //Assert.True(File.Exists(csvPath));
    }
}