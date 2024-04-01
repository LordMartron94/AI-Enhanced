namespace MD.AIE.Library.API;

public interface IAPI
{
    Task<string> GenerateTextAsync(string prompt);
}