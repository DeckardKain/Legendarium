using LegendariumLife;
namespace LegendariumData
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> GetCharacters(string filter);
        IEnumerable<Character> GetAllCharacters();
        Character GetCharacter(int id);
        public void CreateCharacters();
        List<Character> GetAllCharactersByLocation(int id);
        List<Character> GetAllCharactersByPlayerId(int playerId);
        void UpdateCharacter(Character character);
    }
}
