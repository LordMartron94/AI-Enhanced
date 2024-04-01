namespace MD.AIE.Library.API.OpenAI.Models;

internal class CompletionOutputModel
{
    public string Id { get; set; }

    public string Object { get; set; }

    public long Created { get; set; }

    public string Model { get; set; }

    public List<Choice> Choices { get; set; }

    public Usage Usage { get; set; }

    public string SystemFingerprint { get; set; }
}

internal class Choice
{
    public int Index { get; set; }

    public Message Message { get; set; }

    public object Logprobs { get; set; } // Nested properties of logprobs not included in example, so using object

    public string FinishReason { get; set; }
}

internal class Message
{
    public string Role { get; set; }

    public string Content { get; set; }
}

internal class Usage
{
    public int PromptTokens { get; set; }

    public int CompletionTokens { get; set; }

    public int TotalTokens { get; set; }
}