using System.ComponentModel.DataAnnotations;

namespace SeafoodSharp.Shared;

public class Review
{
    [Required]
    [Range(1, 5)]
    public int Food { get; set; }

    [Required]
    [Range(1, 5)]
    public int Service { get; set; }

    [Required]
    [Range(1, 5)]
    public int Ambiance { get; set; }

    [Required]
    [Range(1, 5)]
    public int Overall { get; set; }

    public string? Comment { get; set; }
}
