using LegendariumWorld;
using System.Resources;

namespace LegendariumData
{
    public interface ILocationRepository
    {
        // Location
        void SaveLocations(List<Location> items);
        void SaveLocation(Location location);
        void UpdateLocation(Location location);
        Location GetLocationByName(string name);
        List<Location> GetAllLocations();
        List<Location> GetSurfaceLevelLocationsByPlanetId(int planetId);
        List<Location> GetAllSubLocations();
        bool CoordinateCheck(int xCoordinate, int yCoordinate);
        void DeleteLocations();

        // GameMapItem 
        void SaveGameMapItems(List<GameMapItem> items);
        List<GameMapItem> GetGameMapItemsByLocation(Location location);
        GameMapItem GetGameMapItemByCoordinate(int x,int y,int z);
        

        // Resources
        void SaveResources(List<Resource> resources);
        List<Resource> GetResourcesByTile(GameMapItem gameMap);
    }
}
