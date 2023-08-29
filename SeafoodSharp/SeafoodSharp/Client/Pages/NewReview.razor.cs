using System.Net.Http.Json;
using SeafoodSharp.Client.Analyzer;
using SeafoodSharp.Client.BasicStatistics;
using SeafoodSharp.Shared;

namespace SeafoodSharp.Client.Pages;

public partial class NewReview
{
    Review CustomersReview { get; set; } = new();

    /// <summary>
    /// Average value of valid reviews (= reviews between min and max allowed values).
    /// </summary>
    decimal AvgValidReview { get; set; }
    /// <summary>
    /// Min value of valid reviews (= reviews between min and max allowed values).
    /// </summary>
    public int MinValidReview { get; set; }
    /// <summary>
    /// Max value of valid reviews (= reviews between min and max allowed values).
    /// </summary>
    public int MaxValidReview { get; set; }

    string ResultAnalyzeCustomersReview { get; set; } = string.Empty;

    public async Task SubmitReview()
    {
        ResultAnalyzeCustomersReview = ReviewAnalyzer.AnalyzeReviewMessage(CustomersReview);

        await Http.PostAsJsonAsync<Review>("Review", CustomersReview);
    }

    private void NumericReviewChanged()
    {
        int[] reviews = new[] { CustomersReview.Food, CustomersReview.Service, CustomersReview.Ambiance, CustomersReview.Overall };

        AvgValidReview = BasicStatisticsReviews.AvgValidReview(reviews);
        MinValidReview = BasicStatisticsReviews.MinValidReview(reviews);
        MaxValidReview = BasicStatisticsReviews.MaxValidReview(reviews);
    }

    private string FormatStat(int review)
    {        
        if (BasicStatisticsReviews.IsValidReview(review))
            return review.ToString();
        else
            return "-";
    }

    private string FormatStat(decimal review)
    {
        if (BasicStatisticsReviews.IsValidReview((int)review))
            return review.ToString("#.##");
        else
            return "-";
    }

}