using LegendariumWorld;
using Microsoft.EntityFrameworkCore;

namespace LegendariumData
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly LegendariumDbContext _context;

        public PlanetRepository(LegendariumDbContext context)
        {
            _context = context;

        }

        public void SavePlanet(Planet planet)
        {
            _context.Planet.Add(planet);
            _context.SaveChanges();
        }

        public Planet GetPlanet()
        {
            try
            {
                return _context.Planet.FirstOrDefault();
                //return _context.Planet.Include("Coordinates").First();
            }
            catch (Exception)
            {
                return new Planet();
            }
            
        }
    }
}
