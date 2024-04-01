namespace MD.AIE.Library.API.OpenAI.Models;

internal struct OpenAIConfig
{
    internal string ApiKey { get; set; }
    internal string LLMToUse { get; set; }
    
    internal OpenAIConfig(string apikey, string llmToUse)
    {
        ApiKey = apikey;
        LLMToUse = llmToUse;
    }
}