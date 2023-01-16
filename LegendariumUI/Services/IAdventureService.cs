using LegendariumAdventure;
using LegendariumLife;
using LegendariumWorld;

namespace LegendariumUI.Services
{
    public interface IAdventureService
    {
        void CreateNewAdventure(int playerId, List<Character> characters, Location startLocation, Location destination, string intention, string adventureType);
        List<AdventureOfLegend> GetAllAdventuresByPlayerId(int playerId);
        //void UpdateAdventure(int adventureId);
    }
}