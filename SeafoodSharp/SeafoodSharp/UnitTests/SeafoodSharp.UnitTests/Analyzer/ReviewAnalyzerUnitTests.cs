using SeafoodSharp.Client.Analyzer;

namespace SeafoodSharp.Client.UnitTests;

[TestClass]
public class ReviewAnalyzerUnitTests
{
    [TestMethod]
    public void LastFiveReviewsFiveStarts_AllFiveStarts()
    {
        // Arrange
        List<int> lastFiveStarts = new() { 5, 5, 5, 5, 5 };
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.LastFiveReviewsFiveStarts(lastFiveStarts);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LastFiveReviewsFiveStarts_NoFiveStarts()
    {
        // Arrange
        List<int> lastFiveStarts = new() { 4, 4, 4, 4, 4 };
        bool expected = false;

        // Act
        bool actual = ReviewAnalyzer.LastFiveReviewsFiveStarts(lastFiveStarts);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}