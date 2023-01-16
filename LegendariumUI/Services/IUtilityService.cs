using LegendariumLife;
using LegendariumWorld;

namespace LegendariumUI.Services
{
    public interface IUtilityService
    {
        Task<Player> GetPlayer();
        Task<int> GetPlayerId();
        Task<string> GetPlayerToken();
        List<CardOfLegend> GetPlayerCards(int id);
        List<Location> GetPlayerLocations(int playerId);
        void AddPlayerLocations(int playerId, List<Location> locations);
        void AddPlayerLocation(int playerId, int locationId);



    }
}
