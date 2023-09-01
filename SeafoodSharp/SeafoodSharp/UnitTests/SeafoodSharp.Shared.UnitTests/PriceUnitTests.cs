namespace SeafoodSharp.Shared.UnitTests;

[TestClass]
public class PriceUnitTests
{
    [TestMethod]
    public void FormattedText_Amount1_CurrencyEuro()
    {
        // Arrange
        Price price = new(1, "€");
        string expected = "1 €";

        // Act
        string actual = price.FormattedText();

        // Assert
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void FormattedText_Amount0_NullCurrency()
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
    public void FormattedText_Amount2_EmptyCurrency()
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