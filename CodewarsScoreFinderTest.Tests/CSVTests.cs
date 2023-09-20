namespace CodewarsScoreFinderTest.Tests;

public class UnitTest1
{
    [Fact]
    public void CSVFileNotFound()
    {
        string relativeFilePath = @"ClassLists/C#4.csv";

        string csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);

        Assert.ThrowsAny<DirectoryNotFoundException>(() => CSV.ReadCSV(csvPath));
    }
}