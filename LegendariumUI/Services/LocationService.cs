using LegendariumData;
using LegendariumWorld;

namespace LegendariumUI.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public List<Location> GetLocations()
        {
            var locations = _locationRepository.GetAllLocations();

            return locations;
        }

        public void UpdateLocation(Location location)
        {
            _locationRepository.UpdateLocation(location);
        }

        public void DeleteLocations()
        {
            _locationRepository.DeleteLocations();
        }

        public void SaveImage(Location location, string B64)
        {
            byte[] img = Convert.FromBase64String(B64);
            File.WriteAllBytes($"E:\\Projects\\Coding\\Legendarium\\TheLegendBegins\\Legendarium\\LegendariumUI\\wwwroot\\img\\AIGenImg\\{location.Name}-{location.Biome}.png", img);

            location.Img = String.Format("/img/AIGenImg/" + location.Name + "-" + location.Biome + ".png");

            UpdateLocation(location);
        }

        public Location GetLocationByName(string name)
        {
            var location = _locationRepository.GetLocationByName(name);
            return location;
        }

        public void CreateLocations(Planet planet)
        {
            var locations = LocationManager.CreateLocations(planet);
            var prompt = "";

            // get AI picture

            //foreach (Location location in locations)
            //{
            //    if (location.IsOnSurface)
            //    {
            //        prompt = "Surface level " + location.Biome;
            //    }

            //    prompt = location.Biome;

            //    var result = _aIService.GetPicture(prompt);

            //    location.Img = result.Result;
            //}
            _locationRepository.SaveLocations(locations);
        }

        public void CreateSettlement(Location location, int xCoordinate, int yCoordinate)
        {
            var settlement = LocationManager.CreateChildLocation(location, "Settlement", xCoordinate, yCoordinate);
            _locationRepository.SaveLocation(settlement);
        }

        //public void CreateSettlementRandomStart(Location location) 
        //{
        //    var random = new Random();
        //    double xCoordinate;
        //    double yCoordinate;           

        //    do
        //    {
        //        xCoordinate = random.NextDouble() * (location.CoordinateX2 - location.CoordinateX1) + location.CoordinateX1;
        //        yCoordinate = random.NextDouble() * (location.CoordinateY2 - location.CoordinateY1) + location.CoordinateY1;
        //    }
        //    while (CoordinateCheck(xCoordinate, yCoordinate, 2));


        //    var settlement = LocationManager.CreateChildLocation(location, "Settlement", Math.Round(xCoordinate,2), Math.Round(yCoordinate,2));
        //    _locationRepository.SaveLocation(settlement);
        //}

        public List<Location> GetSurfaceLevelLocationsByPlanetId(int planetId)
        {
            var locations = _locationRepository.GetSurfaceLevelLocationsByPlanetId(planetId);
            return locations;
        }

        public List<Location> GetAllSubLocations()
        {
            var locations = _locationRepository.GetAllSubLocations();
            return locations;
        }

        public void CreateGameMapItems(Location location)
        {
            var gameMapItems = LocationManager.CreateGameMapItems(location);
            _locationRepository.SaveGameMapItems(gameMapItems);
        }

        public void CreateSettlementRandomStart(Location location)
        {
            throw new NotImplementedException();
        }

        public List<GameMapItem> GetGameMapItemsByLocation(Location location)
        {

            var gameMapItems = _locationRepository.GetGameMapItemsByLocation(location);
            return gameMapItems;
        }

        public List<Resource> GetResourcesByTile(GameMapItem gameMap)
        {
            var resources = _locationRepository.GetResourcesByTile(gameMap);
            return resources;
        }

        public void CreateResourcesByTile(List<GameMapItem> gameMapItems)
        {
            var resources = LocationManager.CreateResources(gameMapItems);
            _locationRepository.SaveResources(resources);
        }

        public GameMapItem GetGameMapItemByCoordinate(int x, int y, int z)
        {
            var gameMapItem = _locationRepository.GetGameMapItemByCoordinate(x, y, z);
            return gameMapItem;
        }

        public List<GameMapItem> GetGameMapItemByCoordinateRange(int x1, int x2, int y1, int y2, int z)
        {


            List<GameMapItem> items = new List<GameMapItem>();

            if(x1 == 0)
            {
                x1 += 1;
            }
            if(y1 == 0)
            {
                y1 += 1;
            }

            var x = x1;
            var y = y1;

            // Gets a row of X.
            do
            {
                do
                {
                    var gameMapItem = _locationRepository.GetGameMapItemByCoordinate(x, y, z);
                    items.Add(gameMapItem);
                    x++;
                }
                while (x <= x2);
                y++; // increment Y by 1 to get the next row of X locations
                x = x1; // Reset X so that its back to the start.
            }
            while (y <= y2);

            return items;

        }
        //private bool CoordinateCheck(double xCoordinate, double yCoordinate, double size) 
        //{
        //    var result = _locationRepository.CoordinateCheck(xCoordinate, yCoordinate, size);
        //    return result;
        //}

    }
}
