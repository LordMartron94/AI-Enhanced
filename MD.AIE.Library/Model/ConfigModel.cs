namespace MD.AIE.Library.Model;

internal struct ConfigModel
{
    public string? APIToUse { get; }
    
    public string? ApiKey { get; }
    public string? LLMToUse { get; }
    
    internal ConfigModel(string? apikey, string? llmToUse, string? apiToUse)
    {
        ApiKey = apikey;
        LLMToUse = llmToUse;
        APIToUse = apiToUse;
    }
}