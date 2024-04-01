using System.Net.Http.Headers;
using System.Text;
using MD.AIE.Library.API.OpenAI.Models;
using MD.AIE.Library.Model;
using Newtonsoft.Json;

namespace MD.AIE.Library.API.OpenAI;

internal class OpenAIAPI : IAPI
{
    private readonly OpenAIConfig _apiConfig;
    private readonly HttpClient _httpClient;
    
    
    internal OpenAIAPI(OpenAIConfig apiConfig)
    {
        _apiConfig = apiConfig;
        _httpClient = new HttpClient();
    }

    private void SetHeaders()
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiConfig.ApiKey);
    }
    
    public async Task<string> GenerateTextAsync(string prompt)
    {
        string endpointUrl = "https://api.openai.com/v1/chat/completions";
        
        MessageModel message = new MessageModel("user", prompt);
        CompletionInputModel input = new CompletionInputModel(_apiConfig.LLMToUse, [message]);
        string payload = input.ToJson();
        
        SetHeaders();
        HttpResponseMessage response = await _httpClient.PostAsync(endpointUrl, new StringContent(payload, Encoding.UTF8, "application/json"));
        
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine(response);
            throw new HttpRequestException(response.ReasonPhrase);
        }
        
        string json = await response.Content.ReadAsStringAsync();
        CompletionOutputModel? output = JsonConvert.DeserializeObject<CompletionOutputModel>(json);
        
        if (output == null)
            throw new Exception("Could not deserialize response");
        
        return output.Choices[0].Message.Content;
    }
}