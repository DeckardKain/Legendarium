using LegendariumWorld;

namespace LegendariumUI.Services
{
    public interface ILocationService
    {
        // Locations
        List<Location> GetLocations();
        void UpdateLocation(Location location);
        void SaveImage(Location location, string B64);
        Location GetLocationByName(string name);
        void CreateLocations(Planet planet);
        void CreateSettlement(Location location, int xCoordinate, int yCoordinate);
        void CreateSettlementRandomStart(Location location);
        GameMapItem GetGameMapItemByCoordinate(int x, int y, int z);
        List<GameMapItem> GetGameMapItemByCoordinateRange(int x1, int x2, int y1, int y2, int z);
        List<Location> GetSurfaceLevelLocationsByPlanetId(int planetId);
        List<Location> GetAllSubLocations();
        void DeleteLocations();

        // GameMapItems
        void CreateGameMapItems(Location location);
        List<GameMapItem> GetGameMapItemsByLocation(Location location);


        // Resources
        void CreateResourcesByTile(List<GameMapItem> gameMapItems);
        List<Resource> GetResourcesByTile(GameMapItem gameMap);
    }
}
