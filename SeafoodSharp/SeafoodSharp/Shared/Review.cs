using System.ComponentModel.DataAnnotations;

namespace SeafoodSharp.Shared;

public class Review
{
    [Required]
    [Range(MinReview, MaxReview)]
    public int Food { get; set; }

    [Required]
    [Range(MinReview, MaxReview)]
    public int Service { get; set; }

    [Required]
    [Range(MinReview, MaxReview)]
    public int Ambiance { get; set; }

    [Required]
    [Range(MinReview, MaxReview)]
    public int Overall { get; set; }

    public string? Comment { get; set; }

    public const int MinReview = 1;
    public const int MaxReview = 5;
}