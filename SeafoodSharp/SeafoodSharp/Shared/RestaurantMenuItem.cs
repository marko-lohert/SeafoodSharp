using System.Text;

namespace SeafoodSharp.Shared;

public class RestaurantMenuItem
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Price Price { get; set; }
    public string Category { get; set; }

    public RestaurantMenuItem(string name, string description, Price price, string category)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }

    public RestaurantMenuItem()
    {
    }

    public RestaurantMenuItem(string name, Price price)
    {
        Name = name;
        Description = string.Empty;
        Price = price;
        Category = string.Empty;
    }

    public string FormattedText()
    {
        var GetShortText = (string? text, int length) => text?.Length > length ? text[..length] : text;

        StringBuilder formattedText = new();

        formattedText.Append(GetShortText(Name, 50));
        formattedText.Append(" - ");
        if (Description is not (null or ""))
        {
            formattedText.Append(GetShortText(Description, 200));
            formattedText.Append(" - ");
        }
        if (Category is not (null or ""))
        {
            formattedText.Append(GetShortText(Category, 50));
            formattedText.Append(" - ");
        }
        formattedText.Append(Price.FormattedText());

        return formattedText.ToString();
    }

    public (string name, decimal priceAmmount, string currencySymbol) GetShortInfo()
    {
        return (Name, Price.Amount, Price.Currency);
    }
}
