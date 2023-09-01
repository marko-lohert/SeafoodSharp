using SeafoodSharp.Client.Analyzer;

namespace SeafoodSharp.Client.UnitTests;

[TestClass]
public class ReviewAnalyzerUnitTests
{
    [TestMethod]
    public void LastFiveReviewsFiveStarts_AllReviewsAre5()
    {
        // Arrange
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.LastFiveReviewsAreFiveStarts(new List<int>() { 5, 5, 5, 5, 5 });

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
        List<int> reviews = firstPartReviews.Concat(secondPartReviews).ToList();

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

    [TestMethod]
    public void LastFiveReviewsFiveStarts_Last4ReviewsAre5ButFifthReviewIs4()
    {
        // Arrange
        List<int> reviews = new() { 5, 5, 5, 5, 4 };
        bool expected = false;

        // Act
        bool actual = ReviewAnalyzer.LastFiveReviewsAreFiveStarts(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReviewsAreGettingVeryGood_Reviews1To5()
    {
        // Arrange
        List<int> reviews = new() { 1, 2, 3, 4, 5 }; // Last five reviews - reviews[0] is the last review.
        bool expected = false;

        // Act
        bool actual = ReviewAnalyzer.ReviewsAreGettingVeryGood(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReviewsAreGettingVeryGood_Reviews5To1()
    {
        // Arrange
        List<int> reviews = new() { 5, 4, 3, 2, 1 }; // Last five reviews - reviews[0] is the last review.
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.ReviewsAreGettingVeryGood(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReviewsAreGettingVeryGood_AllReviewsAre5()
    {
        // Arrange
        List<int> reviews = new() { 5, 5, 5, 5, 5 }; // Last five reviews - reviews[0] is the last review.
        bool expected = false;

        // Act
        bool actual = ReviewAnalyzer.ReviewsAreGettingVeryGood(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReviewsEndedInExtreme_AllReviewsAre5()
    {
        // Arrange
        List<int> reviews = new() { 5, 5, 5, 5, 5 }; // Last five reviews - reviews[0] is the last review.
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.ReviewsEndedInExtreme(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReviewsEndedInExtreme_ReviewsEndInExtreme1ButDoNotStartInExtreme()
    {
        // Arrange
        List<int> reviews = new() { 1, 3, 3, 3, 3 }; // Last five reviews - reviews[0] is the last review.
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.ReviewsEndedInExtreme(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReviewsEndedInExtreme_ReviewsEndInExtreme5ButDoNotStartInExtreme()
    {
        // Arrange
        List<int> reviews = new() { 5, 3, 3, 3, 3 }; // Last five reviews - reviews[0] is the last review.
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.ReviewsEndedInExtreme(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReviewsEndedInExtreme_ReviewsStartInExtreme1ButDoNotEndInExtreme()
    {
        // Arrange
        List<int> reviews = new() { 3, 3, 3, 3, 1 }; // Last five reviews - reviews[0] is the last review.
        bool expected = false;

        // Act
        bool actual = ReviewAnalyzer.ReviewsEndedInExtreme(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ReviewsEndedInExtreme_ReviewsStartInExtreme5ButDoNotEndInExtreme()
    {
        // Arrange
        List<int> reviews = new() { 3, 3, 3, 3, 1 }; // Last five reviews - reviews[0] is the last review.
        bool expected = false;

        // Act
        bool actual = ReviewAnalyzer.ReviewsEndedInExtreme(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsThankYouMessage_StartsWithUpperCaseThankYou()
    {
        // Arrange
        string message = "Thank you for the great time";
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.IsThankYouMessage(message);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsThankYouMessage_StartsWithUpperCaseThanks()
    {
        // Arrange
        string message = "Thanks for the great time";
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.IsThankYouMessage(message);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsThankYouMessage_StartsWithLowerCaseThankYou()
    {
        // Arrange
        string message = "thank you for the great time";
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.IsThankYouMessage(message);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsThankYouMessage_StartsWithLowerCaseThanks()
    {
        // Arrange
        string message = "thanks for the great time";
        bool expected = true;

        // Act
        bool actual = ReviewAnalyzer.IsThankYouMessage(message);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsThankYouMessage_DoesNotStartsWithThankYouOrThanks()
    {
        // Arrange
        string message = "I had a great time";
        bool expected = false;

        // Act
        bool actual = ReviewAnalyzer.IsThankYouMessage(message);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}