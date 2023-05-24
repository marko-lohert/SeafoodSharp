using System.Text;

namespace SeafoodSharp.Shared;

public class RestaurantMenuItem(string name, string description, Price price, string category)
{
    public string Name { get; set; } = name;
    public string? Description { get; set; } = description;
    public Price Price { get; set; } = price;

    public RestaurantMenuItem()
        : this(string.Empty, string.Empty, new Price(), string.Empty)
    {
    }

    public RestaurantMenuItem(string name, Price price)
        : this(name, string.Empty, price, string.Empty)
    {
    }

    public string FormattedText()
    {
        var GetShortText = (string? text, int length = 50) => text?.Length > length ? text[..length] : text;

        StringBuilder formattedText = new();

        formattedText.Append(GetShortText(Name));
        formattedText.Append(" - ");
        if (Description is not (null or ""))
        {
            formattedText.Append(GetShortText(Description, 200));
            formattedText.Append(" - ");
        }
        if (category is not (null or ""))
        {
            formattedText.Append(GetShortText(category));
            formattedText.Append(" - ");
        }

        if (Price is not null)
            formattedText.Append(Price.FormattedText());

        return formattedText.ToString();
    }

    public (string name, decimal priceAmmount, string currencySymbol) GetShortInfo()
    {
        return (Name, Price.Amount, Price.Currency);
    }
}
