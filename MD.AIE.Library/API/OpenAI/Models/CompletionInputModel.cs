using Newtonsoft.Json;

namespace MD.AIE.Library.API.OpenAI.Models;

internal struct CompletionInputModel
{
    public string model { get; }
    public List<MessageModel> messages { get; }
    
    internal CompletionInputModel(string model, List<MessageModel> messages)
    {
        this.model = model;
        this.messages = messages;
    }

    internal string ToJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}