using SeafoodSharp.Shared;

namespace SeafoodSharp.Client.Analyzer;

public static class ReviewAnalyzer
{
    public static AnalysisResult AnalyzeLastFiveOverallReviews(List<int> lastFiveReviews)
    {
        string resultInfo = $"This analysis was run on {DateTime.Now.ToShortDateString()} at {DateTime.Now.ToShortTimeString()}.";

        AnalysisResult analysis = new();

        if (LastFiveReviewsFiveStarts(lastFiveReviews))
            analysis.Results.Add("Last five reviews in the category 'overall' have 5 stars.");

        if (ReviewsAreGettingVeryGood(lastFiveReviews))
            analysis.Results.Add("The reviews in the category 'overall' are getting very good.");

        if (ReviewsEndedInExtreme(lastFiveReviews))
            analysis.Results.Add("Reviews has ended in extreme (1 or 5 stars).");

        string shortSummary = ReviewsShortSummary(lastFiveReviews);
        analysis.Results.Add(shortSummary);

        return analysis;
    }

    public static bool LastFiveReviewsFiveStarts(List<int> lastFiveReviews)
    {
        for (int i = 0; i < 5; i++)
        {
            if (lastFiveReviews[i] != 5)
                return false;
        }

        return true;
    }

    public static bool ReviewsAreGettingVeryGood(List<int> lastFiveReviews)
    {
        return lastFiveReviews[0] >= 4 && lastFiveReviews[1] >= 3 && lastFiveReviews[4] <= 3;
    }

    private static bool ReviewsEndedInExtreme(List<int> lastFiveReviews)
    {
        return (lastFiveReviews[0] == 1 || lastFiveReviews[0] == 5);
    }

    public static string ReviewsShortSummary(List<int> lastFiveReviews)
    {
        int sum = 0;
        for (int i = 1; i < 4; i++)
        {
            sum += lastFiveReviews[i];
        }
        double avg = sum / 3.0;

        return $"Last five reviews started with {lastFiveReviews[0]} stars, and finished with {lastFiveReviews[4]} stars. The average of reviews in between first and last (not including first and last) is {avg} stars.";
    }

    public static string AnalyzeReviewMessage(Review review)
    {
        if (review?.Comment is null or "")
            return string.Empty;

        if (review.Comment[0] == '¿' && review.Comment.Length > 10 && review.Comment[review.Comment.Length - 1] == '?')
        {
            string questionText = review.Comment.Substring(1, review.Comment.Length - 2);
            return $"That comment seems like a question asked in Spanish. We'll translate \"{questionText}\". Thank you for your question!";
        }

        if (IsThankYouMessage(review.Comment))
            return "You're welcome!";

        return string.Empty;
    }

    private static bool IsThankYouMessage(string message)
    {
        if (message == null)
            return false;

        ReadOnlySpan<char> messageAllLowerCase = message.ToLower().AsSpan();

        if (messageAllLowerCase.StartsWith("thank you") || messageAllLowerCase.StartsWith("thanks"))
            return true;
        else
            return false;
    }
}
