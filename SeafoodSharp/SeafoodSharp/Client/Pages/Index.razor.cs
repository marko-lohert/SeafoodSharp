using System.Net.Http.Json;
using SeafoodSharp.Client.Analyzer;
using SeafoodSharp.Shared;

namespace SeafoodSharp.Client.Pages;

public partial class Index
{
    Review NewReview { get; set; } = new();

    string ResultAnalyzeNewReview { get; set; } = string.Empty;

    public async Task SubmitReview()
    {
        ResultAnalyzeNewReview = ReviewAnalyzer.AnalyzeReviewMessage(NewReview);

        await Http.PostAsJsonAsync<Review>("Review", NewReview);
    }
}
