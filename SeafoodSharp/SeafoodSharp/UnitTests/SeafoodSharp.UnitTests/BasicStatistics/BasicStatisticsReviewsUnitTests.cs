using SeafoodSharp.Client.BasicStatistics;

namespace SeafoodSharp.Client.UnitTests.BasicStatistics;

[TestClass]
public class BasicStatisticsReviewsUnitTests
{
    [TestMethod]
    public void AvgValidReview_Reviews2To5()
    {
        // Arrange
        int[] reviews = [2, 3, 4, 5];
        decimal expected = 3.5m;

        // Act
        decimal actual = BasicStatisticsReviews.AvgValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MaxValidReview_Reviews2To5()
    {
        // Arrange

        // To demonstrate a specific part of C# 12 feature "Collection expressions" (in the later branch of code),
        // the array of reviews is built by concatenating two arrays.  
        int[] firstPartReviews = [2, 3];
        int[] secondPartReviews = [4, 5];
        int[] reviews = [..firstPartReviews, ..secondPartReviews];

        int expected = 5;

        // Act
        int actual = BasicStatisticsReviews.MaxValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MinValidReview_Reviews2To5()
    {
        // Arrange

        // To demonstrate a specific part of C# 12 feature "Collection expressions" (in the later branch of code),
        // Span<int> and stackalloc will be used to create an array of reviews.  
        Span<int> reviews = [2, 3, 4, 5];

        int expected = 2;

        // Act
        int actual = BasicStatisticsReviews.MinValidReview(reviews.ToArray());

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AvgValidReview_2Valid2InvalidReviews()
    {
        // Arrange
        int[] reviews = [3, 5, 0, 10];
        decimal expected = 4m;

        // Act
        decimal actual = BasicStatisticsReviews.AvgValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MaxValidReview_2Valid2InvalidReviews()
    {
        // Arrange
        int[] reviews = [3, 5, 0, 10];
        int expected = 5;

        // Act
        int actual = BasicStatisticsReviews.MaxValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MinValidReview_2Valid2InvalidReviews()
    {
        // Arrange
        int[] reviews = [3, 5, 0, 10];
        int expected = 3;

        // Act
        int actual = BasicStatisticsReviews.MinValidReview(reviews.ToArray());

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AvgValidReview_AllMinReviews()
    {
        // Arrange
        int[] reviews = [1, 1, 1, 1];
        decimal expected = 1m;

        // Act
        decimal actual = BasicStatisticsReviews.AvgValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MaxValidReview_AllMinReviews()
    {
        // Arrange
        int[] reviews = [1, 1, 1, 1];
        int expected = 1;

        // Act
        int actual = BasicStatisticsReviews.MaxValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MinValidReview_AllMinReviews()
    {
        // Arrange
        int[] reviews = [1, 1, 1, 1];
        int expected = 1;

        // Act
        int actual = BasicStatisticsReviews.MinValidReview(reviews.ToArray());

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AvgValidReview_AllMaxReviews()
    {
        // Arrange
        int[] reviews = [5, 5, 5, 5];
        decimal expected = 5m;

        // Act
        decimal actual = BasicStatisticsReviews.AvgValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MaxValidReview_AllMaxReviews()
    {
        // Arrange
        int[] reviews = [5, 5, 5, 5];
        int expected = 5;

        // Act
        int actual = BasicStatisticsReviews.MaxValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MinValidReview_AllMaxReviews()
    {
        // Arrange
        int[] reviews = [5, 5, 5, 5];
        int expected = 5;

        // Act
        int actual = BasicStatisticsReviews.MinValidReview(reviews.ToArray());

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AvgValidReview_AllInvalidReviews()
    {
        // Arrange
        int[] reviews = [0, -1, 6, 10];
        decimal expected = 0m;

        // Act
        decimal actual = BasicStatisticsReviews.AvgValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MaxValidReview_AllInvalidReviews()
    {
        // Arrange
        int[] reviews = [0, -1, 6, 10];
        int expected = 0;

        // Act
        int actual = BasicStatisticsReviews.MaxValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MinValidReview_AllInvalidReviews()
    {
        // Arrange
        int[] reviews = [0, -1, 6, 10];
        int expected = 0;

        // Act
        int actual = BasicStatisticsReviews.MinValidReview(reviews.ToArray());

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AvgValidReview_NullReviews()
    {
        // Arrange
        int[]? reviews = null;
        decimal expected = 0m;

        // Act
        decimal actual = BasicStatisticsReviews.AvgValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MaxValidReview_NullReviews()
    {
        // Arrange
        int[]? reviews = null;
        int expected = 0;

        // Act
        int actual = BasicStatisticsReviews.MaxValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MinValidReview_NullReviews()
    {
        // Arrange
        int[]? reviews = null;
        int expected = 0;

        // Act
        int actual = BasicStatisticsReviews.MinValidReview(reviews?.ToArray());

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AvgValidReview_EmptyArrayReviews()
    {
        // Arrange
        int[] reviews = Array.Empty<int>();
        decimal expected = 0m;

        // Act
        decimal actual = BasicStatisticsReviews.AvgValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MaxValidReview_EmptyArrayReviews()
    {
        // Arrange
        int[] reviews = Array.Empty<int>();
        int expected = 0;

        // Act
        int actual = BasicStatisticsReviews.MaxValidReview(reviews);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MinValidReview_EmptyArrayReviews()
    {
        // Arrange
        int[] reviews = Array.Empty<int>();
        int expected = 0;

        // Act
        int actual = BasicStatisticsReviews.MinValidReview(reviews?.ToArray());

        // Assert
        Assert.AreEqual(expected, actual);
    }
}