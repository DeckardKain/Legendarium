using LegendariumLife;

namespace LegendariumData
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly LegendariumDbContext _context;

        public CharacterRepository(LegendariumDbContext context)
        {            
            _context = context;
        }

        public IEnumerable<Character> GetCharacters(string filter)
        {
            return _context.Character.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }

        public Character GetCharacter(int id)
        {
            return _context.Character.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Character> GetAllCharacters()
        {
            return _context.Character.ToList();
        }

        public void CreateCharacters()
        {
            var characters = CharacterManager.CreateCharacters();
            foreach(Character c in characters)
            {
                _context.Character.Add(c);
            }
            _context.SaveChanges();
        }

        public List<Character> GetAllCharactersByLocation(int id)
        {
            var characters = _context.Character.Where(x => x.LocationId == id).ToList();
            return characters;
        }

        public void UpdateCharacter(Character character)
        {
            _context.Character.Update(character);
            _context.SaveChanges();
        }

        public List<Character> GetAllCharactersByPlayerId(int playerId)
        {
            var characters = _context.Character.Where(x => x.PlayerId == playerId).ToList();
            return characters;
        }
    }
}