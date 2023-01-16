using LegendariumAdventure;

namespace LegendariumData
{
    public interface IAdventureRepository
    {
        void NewAdventure(AdventureOfLegend adventure);
        List<AdventureOfLegend> GetAdventuresByPlayerId(int playerId);
    }
}