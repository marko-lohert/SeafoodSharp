namespace SeafoodSharp.Shared;

public class Price(decimal amount, string currency)
{
    public decimal Amount { get; set; } = amount;
    public string Currency { get; set; } = currency;

    public Price()
        : this(default, string.Empty)
    {
    }

    public string FormattedText()
    {
        return $"{Amount} {Currency}";
    }
}
