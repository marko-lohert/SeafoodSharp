namespace SeafoodSharp.Shared;

public struct ReviewsAverage(DateTime dateTimeAvgCalculated)
{
    public DateTime DateTimeAvgCalculated { get; set; } = dateTimeAvgCalculated;

    public float FoodAvg { get; set; }
    public float ServiceAvg { get; set; }
    public float AmbianceAvg { get; set; }
    public float OverallAvg { get; set; }

    public int TotalReviews { get; set; }
}
