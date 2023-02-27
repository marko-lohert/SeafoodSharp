using Microsoft.AspNetCore.Mvc;
using SeafoodSharp.Server.DAL;
using SeafoodSharp.Shared;

namespace SeafoodSharp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ILogger<ReviewController> _logger;

    public ReviewController(ILogger<ReviewController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetReviews/Overall/Last/{count}")]
    public IEnumerable<int> GetReviewsOverallLast(int count)
    {
        ReviewDAO dao = new();
        return dao.GetLastOverallReviews(count);
    }

    [HttpGet("GetReviews/Average")]
    public ReviewsAverage GetReviewsAverage()
    {
        ReviewDAO dao = new();
        return dao.GetReviewsAverage();
    }

    [HttpPost]
    public void Post([FromBody] Review review)
    {
        ReviewDAO dao = new();
        dao.SaveReview(review);
    }

    [HttpGet("Export/Average/json")]
    public string ExportJsonAverage()
    {
        ReviewsAverage reviewsAverage = GetReviewsAverage();

        string reportWarning = reviewsAverage.TotalReviews switch
        {
            0 => "No reviews",
            >= 1 and <= 30 => "Too few reviews. At least 30 reviews are necessary for calculating a meaningful average.",
            _ => "0 warnings"
        };

        string averageReport = @$"
            {{
                ""review"": {{
                    ""Food"": ""{reviewsAverage.FoodAvg}"",
                    ""Service"": ""{reviewsAverage.ServiceAvg}"",
                    ""Ambiance"": ""{reviewsAverage.AmbianceAvg}"",
                    ""Overall"": ""{reviewsAverage.OverallAvg}""
                }},
                ""info"": {{
                    ""TotalReviews"" : ""{reviewsAverage.TotalReviews}"",
                    ""DateTimeAvgCalculated"" : ""{reviewsAverage.DateTimeAvgCalculated}""
                }},
                ""warning"" : ""{reportWarning}""
            }}
            ";

        return averageReport;
    }
}