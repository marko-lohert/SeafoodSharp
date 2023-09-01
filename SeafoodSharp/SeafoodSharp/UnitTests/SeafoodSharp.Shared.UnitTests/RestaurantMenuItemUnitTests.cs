namespace SeafoodSharp.Shared.UnitTests;

[TestClass]
public class RestaurantMenuItemUnitTests
{
    [TestMethod]
    public void FormattedText_AllData_NotNullAndNotEmpty()
    {
        // Arrange
        RestaurantMenuItem menuItem = new("Deep-fired calamari", "Deep-fired fresh calamari", new Price(10, "€"), "Main Dish");
        string expected = "Deep-fired calamari - Deep-fired fresh calamari - Main Dish - 10 €";

        // Act
        string actual = menuItem.FormattedText();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormattedText_OnlyNameAndPrice()
    {
        // Arrange
        RestaurantMenuItem menuItem = new("Tuna", new Price(14, "$"));
        string expected = "Tuna - 14 $";

        // Act
        string actual = menuItem.FormattedText();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormattedText_NameDescriptionAndPrice()
    {
        // Arrange
        RestaurantMenuItem menuItem = new("Shrimp risotto", "Creamy shrimp risotto", new Price(15, "Euro"), category: null);
        string expected = "Shrimp risotto - Creamy shrimp risotto - 15 Euro";

        // Act
        string actual = menuItem.FormattedText();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormattedText_NamePriceAndCategory()
    {
        // Arrange
        RestaurantMenuItem menuItem = new("Shrimp risotto", description: null, new Price(12, "€"), "Main Dish");
        string expected = "Shrimp risotto - Main Dish - 12 €";

        // Act
        string actual = menuItem.FormattedText();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormattedText_AllData_Null_Price_0()
    {
        // Arrange
        RestaurantMenuItem menuItem = new(null, null, new Price(0, null), null);
        string expected = " - 0 ";

        // Act
        string actual = menuItem.FormattedText();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetShortInfo_AllData_NotNullAndNotEmpty()
    {
        // Arrange
        RestaurantMenuItem menuItem = new("Calamari", "Deep-fired fresh calamari", new Price(20, "$"), "Main Dish");
        (string name, decimal priceAmmount, string currencySymbol) expected = ("Calamari", 20, "$");

        // Act
        (string name, decimal priceAmmount, string currencySymbol) actual = menuItem.GetShortInfo();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetShortInfo_AllData_Null_Price_0()
    {
        // Arrange
        RestaurantMenuItem menuItem = new(null, new Price(0, null));
        (string name, decimal priceAmmount, string currencySymbol) expected = (null, 0, null);

        // Act
        (string name, decimal priceAmmount, string currencySymbol) actual = menuItem.GetShortInfo();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormattedText_PriceNull()
    {
        // Arrange
        RestaurantMenuItem menuItem = new("Tuna", price: null);
        string expected = "Tuna - ";

        // Act
        string actual = menuItem.FormattedText();

        // Assert
        Assert.AreEqual(expected, actual);
    }

}