using MD.AIE.Library.Model;

namespace MD.AIE.Library.Factory;

public class CharacterFactory
{
    public CharacterModel Create(Dictionary<string, string> characterMetadata)
    {
        return new CharacterModel(characterMetadata);
    }
}