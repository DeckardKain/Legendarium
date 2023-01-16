using LegendariumRandom;

namespace LegendariumLife
{
    public class CharacterManager
    {        
        public static List<Character> CreateCharacters()
        {
            List<Character> characters = new List<Character>();

            var amount = 10;
            for (int i = 0; i < amount; i++)
            {
                var character = new Character()
                {                    
                    Name = RandomManager.CreateRandomName(),
                    LocationId = 1,
                    Stamina = RandomManager.CreateRandomStat(),
                    Strength = RandomManager.CreateRandomStat(),
                    Agility = RandomManager.CreateRandomStat(),
                    Dialect = RandomManager.CreateRandomStat(),
                    Discernement = RandomManager.CreateRandomStat(),
                    Intellect = RandomManager.CreateRandomStat(),
                    Dexterity = RandomManager.CreateRandomStat(),
                    Type = Character.Types.Humanoid.ToString(),
                    Rank = "Not Implemented"
                };

                // modifications
                character.ImageLink = GetPicture(character);

                characters.Add(character);
            };

            return characters;
        }

        private static string GetPicture(Character character)
        {
            return "https://openai-labs-public-images-prod.azureedge.net/user-7vVSEfshutHgMZxyuG6OZTJJ/generations/generation-j55KKu6tOAUjFfZ2P0NOAdBP/image.webp";
        }
    }
}
