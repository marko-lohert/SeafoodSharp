namespace SeafoodSharp.Shared;

public struct ReviewsAverage
{
    public ReviewsAverage(DateTime dateTimeAvgCalculated)
    {
        DateTimeAvgCalculated = dateTimeAvgCalculated;
    }

    public DateTime DateTimeAvgCalculated { get; set; }

    public float FoodAvg { get; set; }
    public float ServiceAvg { get; set; }
    public float AmbianceAvg { get; set; }
    public float OverallAvg { get; set; }

    public int TotalReviews { get; set; }
}
