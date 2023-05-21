namespace SeafoodSharp.Shared;

public class Price
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public Price()
    {
    }

    public string FormattedText()
    {
        return $"{Amount} {Currency}";
    }
}
