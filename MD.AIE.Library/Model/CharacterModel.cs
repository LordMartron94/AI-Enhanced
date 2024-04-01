namespace MD.AIE.Library.Model;

public struct CharacterModel
{
    public Dictionary<string, string> Metadata { get; }

    internal CharacterModel(Dictionary<string, string> metadata)
    {
        Metadata = metadata;
    }
}