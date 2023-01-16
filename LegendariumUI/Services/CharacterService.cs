using LegendariumData;
using LegendariumLife;

namespace LegendariumUI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public List<Character> GetCharactersByLocation(int id)
        {
            var characters = _characterRepository.GetAllCharactersByLocation(id);
            return characters;
        }

        public void AddCharacterToPlayerControl(int characterId, int playerId)
        {
            var character = _characterRepository.GetCharacter(characterId);
            character.PlayerId = playerId;
            _characterRepository.UpdateCharacter(character);
        }

        public List<Character> GetCharactersControlledByPlayer(int playerId)
        {
            var characters = _characterRepository.GetAllCharactersByPlayerId(playerId);
            return characters;            
        }
    }
}
