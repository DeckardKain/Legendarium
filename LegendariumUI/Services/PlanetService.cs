using LegendariumData;
using LegendariumWorld;

namespace LegendariumUI.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _planetRepository;

        public PlanetService(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public void CreatePlanet()
        {
            var planet = PlanetManager.CreatePlanet();
            _planetRepository.SavePlanet(planet);
        }

        public Planet GetPlanet()
        {
            var planet = _planetRepository.GetPlanet();
            return planet;
        }
    }
}
