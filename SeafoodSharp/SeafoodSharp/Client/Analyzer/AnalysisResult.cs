namespace SeafoodSharp.Client.Analyzer;

public class AnalysisResult
{
    public List<string> Results { get; set; } = new();
    public required string AnalysisResultInfo { get; set; }
}
