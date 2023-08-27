namespace SeafoodSharp.Shared.UnitTests;

[TestClass]
public class PriceUnitTests
{
    [TestMethod]
    public void FormattedText_1_Euro()
    {
        // Arrange
        Price price = new(1, "Euro");
        string expected = "1 Euro";

        // Act
        string actual = price.FormattedText();

        // Assert
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void FormattedText_0_NullCurrency()
    {
        // Arrange
        Price price = new(1, null);
        string expected = "1 ";

        // Act
        string actual = price.FormattedText();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormattedText_2_EmptyCurrency()
    {
        // Arrange
        Price price = new(2, string.Empty);
        string expected = "2 ";

        // Act
        string actual = price.FormattedText();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}