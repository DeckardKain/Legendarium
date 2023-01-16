using LegendariumWorld;

namespace LegendariumData
{
    public interface IPlayerRepository
    {
        void CreateNewPlayer(Player player);
        void UpdatePlayerPower(int id, int powerAmount);
        void UpdatePlayerVision(int id, int visionAmount);
        List<Location> GetPlayerKnownLocations(int playerId);
        void AddPlayerLocation(int playerId, int locationId);
        bool PlayerLocationExists(int playerId, int locationId);
    }
}