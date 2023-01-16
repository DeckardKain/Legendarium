using LegendariumAdventure;
using LegendariumData;
using LegendariumLife;
using LegendariumWorld;

namespace LegendariumUI.Services
{
    public class AdventureService : IAdventureService
    {
        private readonly IAdventureRepository _adventureRepository;        

        public AdventureService(IAdventureRepository adventureRepository)
        {
            _adventureRepository = adventureRepository;            
        }

        public void CreateNewAdventure(int playerId, List<Character> characters, Location startLocation, Location destination, string intention, string adventureType)
        {
            //var adventure = AdventureManager.CreateNewAdventure(playerId, characters, startLocation, destination, intention, adventureType);
            //_adventureRepository.NewAdventure(adventure);
        }

        public List<AdventureOfLegend> GetAllAdventuresByPlayerId(int playerId)
        {
            var adventures = _adventureRepository.GetAdventuresByPlayerId(playerId);
            return adventures;
        }

        //public void UpdateAdventure(int adventureId)
        //{
        //    _adventureRepository.UpdateAdventure(adventureId);
        //}

    }
}
