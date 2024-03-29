﻿using SeafoodSharp.Shared;

namespace SeafoodSharp.Client.Analyzer;

public static class ReviewAnalyzer
{
    public static AnalysisResult AnalyzeLastFiveOverallReviews(List<int> lastFiveReviews)
    {
        string resultInfo = $"This analysis was run on {DateTime.Now.ToShortDateString()} at {DateTime.Now.ToShortTimeString()}.";

        AnalysisResult analysis = new()
        {
            AnalysisResultInfo = resultInfo
        };

        if (LastFiveReviewsAreFiveStarts(lastFiveReviews))
            analysis.Results.Add("Last five reviews in the category 'overall' have 5 stars.");

        if (ReviewsAreGettingVeryGood(lastFiveReviews))
            analysis.Results.Add("The reviews in the category 'overall' are getting very good.");

        if (ReviewsEndedInExtreme(lastFiveReviews))
            analysis.Results.Add("Reviews has ended in extreme (1 or 5 stars).");

        string shortSummary = ReviewsShortSummary(lastFiveReviews);
        analysis.Results.Add(shortSummary);

        return analysis;
    }

    public static bool LastFiveReviewsAreFiveStarts(List<int> lastFiveReviews)
    {
        return lastFiveReviews is [5, 5, 5, 5, 5];
    }

    public static bool ReviewsAreGettingVeryGood(List<int> lastFiveReviews)
    {
        return lastFiveReviews is [>= 4, >= 3, _, _, <= 3];
    }

    public static bool ReviewsEndedInExtreme(List<int> lastFiveReviews)
    {
        return lastFiveReviews is [1 or 5, ..];
    }

    public static string ReviewsShortSummary(List<int> lastFiveReviews)
    {
        int[] arrayReviews = lastFiveReviews.ToArray<int>();
        if (arrayReviews is [var first, .. var midArray, int last])
            return $"Last five reviews started with {first} stars, and finished with {last} stars. The average of reviews in between first and last (not including first and last) is {midArray.Average()} stars.";
        else
            return "There is not enough data to generate a short summary.";
    }

    public static string AnalyzeReviewMessage(Review review)
    {
        if (review?.Comment is null or "")
            return string.Empty;

        if (review.Comment is ['¿', .. { Length: > 8 } questionText, '?'])
        {
            return $"That comment seems like a question asked in Spanish. We'll translate \"{questionText}\". Thank you for your question!";
        }

        if (IsThankYouMessage(review.Comment))
            return "You're welcome!";

        return string.Empty;
    }

    public static bool IsThankYouMessage(string message)
    {
        if (message == null)
            return false;

        // We will use pattern matching Span char on a *constant* string,
        // (for the purpose of demo in a conference/meetup talk)
        // so take only the first part of string that may contain one of "thank you" messages that are accepted.
        int endIndex = message.IndexOf('s');
        if (endIndex == -1)
        {
            endIndex = message.IndexOf('u');
            if (endIndex == -1)
                return false;
        }

        ReadOnlySpan<char> messageAllLowerCase = message.ToLower()[..(endIndex + 1)].AsSpan();

        return messageAllLowerCase switch
        {
            "thank you" or "thanks" => true,
            _ => false
        };
    }
}
