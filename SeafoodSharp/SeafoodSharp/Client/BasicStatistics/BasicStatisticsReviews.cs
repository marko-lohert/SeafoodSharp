using SeafoodSharp.Shared;

namespace SeafoodSharp.Client.BasicStatistics;

public class BasicStatisticsReviews
{
    /// <summary>
    /// Calculate average review, but take into account only valid reviews (= reviews between min and max allowed values).
    /// </summary>
    /// <param name="reviews">Input reviews (note: some review may have invalid values).</param>
    /// <returns>Average value of valid reviews or <see cref="AllReviewsAreInvalid"/> if there is no valid review.</returns>
    public static decimal AvgValidReview(int[]? reviews)
    {
        if (reviews is null)
            return AllReviewsAreInvalid;

        int sum = 0;
        int countValidReviews = 0;

        for (int i = 0; i < reviews.Length; i++)
        {
            if (IsValidReview(reviews[i]))
            {
                sum += reviews[i];
                countValidReviews++;
            }
        }

        return (countValidReviews > 0) ? (decimal)sum / countValidReviews : AllReviewsAreInvalid;
    }

    /// <summary>
    /// Find min value of reviews, but take into account only valid reviews (= reviews between min and max allowed values).
    /// </summary>
    /// <param name="reviews">Input reviews (note: some review may have invalid values).</param>
    /// <returns>Min value of valid reviews or <see cref="AllReviewsAreInvalid"/> if there is no valid review.</returns>
    public static int MinValidReview(int[]? reviews)
    {
        if (reviews is null)
            return AllReviewsAreInvalid;

        int min = Review.MaxReview + 1; /// Add 1 to make sure that in case all review are invalid we can detect it, and return <see cref="AllReviewsAreInvalid"/>.

        for (int i = 0; i < reviews.Length; i++)
        {
            if (reviews[i] < min && IsValidReview(reviews[i]))
                min = reviews[i];
        }

        return IsValidReview(min) ? min : AllReviewsAreInvalid;
    }

    /// <summary>
    /// Find max value of reviews, but take into account only valid reviews (= reviews between min and max allowed values).
    /// </summary>
    /// <param name="reviews">Input reviews (note: some review may have invalid values).</param>
    /// <returns>Max value of valid reviews or <see cref="AllReviewsAreInvalid"/> if there is no valid review.</returns>
    public static int MaxValidReview(int[]? reviews)
    {
        if (reviews is null)
            return AllReviewsAreInvalid;

        int max = Review.MinReview - 1; /// Subtract 1 to make sure that in case all review are invalid, we can detect it, and return <see cref="AllReviewsAreInvalid"/>.

        for (int i = 0; i < reviews.Length; i++)
        {
            if (reviews[i] > max && IsValidReview(reviews[i]))
                max = reviews[i];
        }

        return IsValidReview(max) ? max : AllReviewsAreInvalid;
    }

    public static bool IsValidReview(int review) => review >= Review.MinReview && review <= Review.MaxReview;

    /// <summary>
    /// Constant used to indicate that all reviews (send as an argument to a method) are invalid (<see cref="IsValidReview"/>).
    /// </summary>
    private const int AllReviewsAreInvalid = 0;
}