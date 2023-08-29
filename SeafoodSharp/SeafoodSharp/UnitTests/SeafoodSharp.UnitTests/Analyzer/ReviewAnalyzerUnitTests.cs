using SeafoodSharp.Client.Analyzer;

namespace SeafoodSharp.Client.UnitTests;

[TestClass]
public class ReviewAnalyzerUnitTests
{
    [TestMethod]
    public void LastFiveReviewsFiveStarts_AllReviewsAre5()
    {
        // Arrange
        List<int> reviews = new() { 5, 5, 5, 5, 5 };
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.LastFiveReviewsAreFiveStarts(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LastFiveReviewsFiveStarts_Reviews1To5()
    {
        // Arrange

        // To demonstrate a specific part of C# 12 feature "Collection expressions" (in the later branch of code),
        // the list of reviews is built by concatenating two lists.
        List<int> firstPartReviews = new() { 1, 2, 3 };
        List<int> secondPartReviews = new() { 4, 5 };
        List<int> reviews = firstPartReviews.Concat(secondPartReviews).ToList(); ;

        bool expected = false;

        // Act
        bool actual = ReviewAnalyzer.LastFiveReviewsAreFiveStarts(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LastFiveReviewsFiveStarts_AllReviewsAre4()
    {
        // Arrange
        List<int> reviews = new() { 4, 4, 4, 4, 4 };
        bool expected = false;

        // Act
        bool actual = ReviewAnalyzer.LastFiveReviewsAreFiveStarts(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}