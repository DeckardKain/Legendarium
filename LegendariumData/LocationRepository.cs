using LegendariumWorld;
using Microsoft.EntityFrameworkCore;

namespace LegendariumData
{
    public class LocationRepository : ILocationRepository
    {
        private readonly LegendariumDbContext _context;

        public LocationRepository(LegendariumDbContext context)
        {
            _context = context;
        }

        public void SaveLocations(List<Location> locations) 
        {
            foreach(var item in locations)
            {
                _context.Location.Add(item);
                _context.SaveChanges();
            }
        }

        public void DeleteLocations()
        {            
            _context.Location.ExecuteDelete();
        }
        public void SaveLocation(Location location)
        {
            _context.Location.Add(location);
            _context.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            _context.Location.Update(location);
            _context.SaveChanges();
        }

        public void SaveGameMapItems(List<GameMapItem> items)
        {
            _context.GameMapItems.AddRange(items);
            _context.SaveChanges();
        }

        public List<Location> GetAllLocations()
        {
            return _context.Location.ToList();
        }

        public List<Location> GetAllSubLocations()
        {
            return _context.Location.Where(x => x.Type != "Surface Level").ToList();
        }

        public List<Location> GetSurfaceLevelLocationsByPlanetId(int planetId)
        {
            var locations = _context.Location.Where(x => x.PlanetId == planetId).ToList();
            return locations;
        }

        public bool CoordinateCheck(int xCoordinate, int yCoordinate)
        {
            throw new NotImplementedException();
        }

        public List<GameMapItem> GetGameMapItemsByLocation(Location location)
        {
            var gameMapItems = _context.GameMapItems.Where(x => x.ParentLocationId == location.Id).ToList();

            return gameMapItems;
        }

        public GameMapItem GetGameMapItemByCoordinate(int x,int y,int z)
        {
            var gameMapItem = _context.GameMapItems.Where(a => a.X == x && a.Y == y && a.Z == z).FirstOrDefault();
            return gameMapItem;
        }

        public Location GetLocationByName(string name)
        {
            var location = _context.Location.Where(x => x.Name == name).First();
            return location;
        }

        public List<Resource> GetResourcesByTile(GameMapItem gameMap)
        {
            var resources = _context.Resource.Where(x => x.X == gameMap.X && x.Y == gameMap.Y && x.Z == gameMap.Z).ToList();
            return resources;
        }

        public void SaveResources(List<Resource> resources)
        {
            _context.Resource.AddRange(resources);
            _context.SaveChanges();
        }

        //public bool CoordinateCheck(double xCoordinate, double yCoordinate, double size)
        //{
        //    var locationsFound = new List<Location>();

        //    for(double d = xCoordinate; d < xCoordinate+size; d+=0.01)
        //    {
        //        var location = _context.Location.Where(x => x.CoordinateX1 == xCoordinate).First();
        //        if(location != null)
        //        {
        //            locationsFound.Add(location);
        //            d = d + location.Size;
        //        }
        //        Math.Round(d, 2);
        //    }
        //    var subLocations = _context.Location.Where(x => x.Type != "Surface Level").ToList();
        //    var updatedXCoordinate = CheckForAvailableSpaceOnX(xCoordinate, size);
        //    var updatedYCoordinate = CheckForAvailableSpace(yCoordinate, size);

        //    if (subLocations.Any(x => x.CoordinateX1 <= xCoordinate && x.CoordinateX2 >= xCoordinate) ||
        //        subLocations.Any(x => x.CoordinateY1 <= yCoordinate && x.CoordinateY2 >= yCoordinate))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        // Check for available space 
        //private double CheckForAvailableSpaceOnX(double coordinate, double size)
        //{
        //    // get parent location
        //    var parentLocation = _context.Location.Where(x => x.Type == "Surface Level").FirstOrDefault(x => x.CoordinateX1 <= coordinate && x.CoordinateX2 >= coordinate);
        //    // get sub locations from parent
        //    var subLocations = _context.Location.Where(x => x.Type != "Surface Level" && x.XCoordinate >= parentLocation.CoordinateX1 && x.CoordinateX2 <= parentLocation.CoordinateX2).ToList();

        //    if(subLocations.Count > 0)
        //    {
        //        foreach (Location location in subLocations)
        //        {
        //            // If the sublocation's X coordinate is higher than the proposed new X coordinate
        //            if(location.CoordinateX1 > coordinate)
        //            {
        //                // Check to see if there is enough space between the sublocation and the parent location
        //                if(location.CoordinateX1 - size > parentLocation.CoordinateX1)
        //                {
        //                    // There is room on the X for this new location.
        //                    return coordinate;
        //                }
        //                else
        //                {
        //                    // There is no room on the X for this location
        //                    // So lets calculate available space and adjust the coordinate accordingly
        //                    var spaceAvailable = location.CoordinateX1 - parentLocation.CoordinateX1;                            
        //                    coordinate = parentLocation.CoordinateX1;
        //                }

        //            }
        //        }
        //    }



        //    // Check to see 
        //}
    }
}
