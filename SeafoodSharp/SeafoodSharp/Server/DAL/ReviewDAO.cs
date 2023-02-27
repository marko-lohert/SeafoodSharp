using SeafoodSharp.Shared;

namespace SeafoodSharp.Server.DAL;

public class ReviewDAO
{
    public List<int> GetLastOverallReviews(int count)
    {
        // Mock data (prepared for the presentation).

        return Enumerable.Repeat(5, count).ToList();
    }

    public ReviewsAverage GetReviewsAverage()
    {
        // Mock data (prepared for the presentation).

        ReviewsAverage avg = new(dateTimeAvgCalculated: DateTime.Now)
        {
            FoodAvg = 4.4f,
            ServiceAvg = 4.7f,
            AmbianceAvg = 4.3f,
            OverallAvg = 4.5f,

            TotalReviews = 123
        };

        return avg;
    }

    public void SaveReview(Review review)
    {
        // todo
    }
}
