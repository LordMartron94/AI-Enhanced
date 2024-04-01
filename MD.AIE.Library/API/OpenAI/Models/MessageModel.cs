using Newtonsoft.Json;

namespace MD.AIE.Library.API.OpenAI.Models;

internal readonly struct MessageModel(string role, string content)
{
    public string role { get; } = role;
    public string content { get; } = content;
    

    internal string ToJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}