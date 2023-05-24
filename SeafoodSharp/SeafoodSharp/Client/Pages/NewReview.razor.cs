using System.Net.Http.Json;
using SeafoodSharp.Client.Analyzer;
using SeafoodSharp.Shared;

namespace SeafoodSharp.Client.Pages;

public partial class NewReview
{
    Review CustomersReview { get; set; } = new();

    string ResultAnalyzeCustomersReview { get; set; } = string.Empty;

    public async Task SubmitReview()
    {
        ResultAnalyzeCustomersReview = ReviewAnalyzer.AnalyzeReviewMessage(CustomersReview);

        await Http.PostAsJsonAsync<Review>("Review", CustomersReview);
    }
}
