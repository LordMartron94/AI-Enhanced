using MD.AIE.Library.API;
using MD.AIE.Library.API.OpenAI;
using MD.AIE.Library.API.OpenAI.Models;
using MD.AIE.Library.Model;
using Microsoft.Extensions.Configuration;

namespace MD.AIE.Library;

public class AIEnhancedAPI
{
    private readonly IAPI _api;
    private readonly string _dataFolder;
    private readonly ConfigModel _configuration;

    public AIEnhancedAPI()
    {
        _dataFolder = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AI Enhanced");
        _configuration = GetConfig();
        
        _api = GetAPI();
    }

    private IAPI GetAPI()
    {
        switch (_configuration.APIToUse)
        {
            case "OpenAI":
                if (_configuration.ApiKey == null || _configuration.LLMToUse == null)
                    throw new Exception("API Key and Language Model must be set");
                
                return new OpenAIAPI(new OpenAIConfig(_configuration.ApiKey, _configuration.LLMToUse));
            default:
                throw new ArgumentException($"Unknown API: {_configuration.APIToUse}");
        }
    }

    private ConfigModel GetConfig()
    {
        string configPath = Path.Join(_dataFolder, "config.ini");
        
        if (!Directory.Exists(_dataFolder))
            Directory.CreateDirectory(_dataFolder);
        
        if (!File.Exists(configPath))
            File.Create(configPath).Close();
        
        Console.WriteLine($"Loading configuration from {configPath}");
        
        IConfigurationBuilder configBuilder = new ConfigurationBuilder()
            .SetBasePath(_dataFolder)
            .AddIniFile("config.ini");
        IConfigurationRoot configuration = configBuilder.Build();
        
        return new ConfigModel(
            configuration["OpenAI:openai_key"], 
            configuration["OpenAI:openai_llm"], 
            configuration["APP:api_to_use"]
            );
    }
    
    public async Task<string> GenerateText(string prompt)
    {
        return await _api.GenerateTextAsync(prompt);
    }
}