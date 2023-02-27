using System.Net.Http.Json;
using SeafoodSharp.Client.Analyzer;
using SeafoodSharp.Shared;

namespace SeafoodSharp.Client.Pages;

public partial class ReviewAnalysis
{
    AnalysisResult? Analysis { get; set; }
    ReviewsAverage Average { get; set; }

    file? ExportFileInfo { get; set; }

    protected override async Task OnInitializedAsync()
    {
        List<int> lastReviews = await GetReviewsOverallLast(5);

        Analysis = ReviewAnalyzer.AnalyzeLastFiveOverallReviews(lastReviews);
        Average = await GetReviewsAverage();

        ExportFileInfo = new()
        {
            Name = "Seafood Sharp_Reviews_Average.json",
            ContentAPI = "Review/Export/Average/json"
        };
    }

    public async Task<List<int>> GetReviewsOverallLast(int count)
    {
        return await Http.GetFromJsonAsync<List<int>>($"Review/GetReviews/Overall/Last/{count}") ?? new List<int>();
    }

    public async Task<ReviewsAverage> GetReviewsAverage()
    {
        return await Http.GetFromJsonAsync<ReviewsAverage>("Review/GetReviews/Average");
    }

}

public class file : IExportFileInfo
{
    public string? Name { get; set; }
    public string? ContentAPI { get; set; }
}

public interface IExportFileInfo
{
    string? Name { get; set; }
    string? ContentAPI { get; set; }
}
