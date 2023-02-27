namespace SeafoodSharp.Shared;

public struct ReviewsAverage
{
    public ReviewsAverage(DateTime dateTimeAvgCalculated)
    {
        DateTimeAvgCalculated = dateTimeAvgCalculated;

        FoodAvg = 0;
        ServiceAvg = 0;
        AmbianceAvg = 0;
        OverallAvg = 0;

        TotalReviews = 0;
    }

    public DateTime DateTimeAvgCalculated { get; set; }

    public float FoodAvg { get; set; }
    public float ServiceAvg { get; set; }
    public float AmbianceAvg { get; set; }
    public float OverallAvg { get; set; }

    public int TotalReviews { get; set; }
}
