using LegendariumLife;

namespace LegendariumUI.Services
{
    public interface ICharacterService
    {
        List<Character> GetCharactersByLocation(int id);
        void AddCharacterToPlayerControl(int characterId, int playerId);
        List<Character> GetCharactersControlledByPlayer(int playerId);
    }
}