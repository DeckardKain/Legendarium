using LegendariumWorld;

namespace LegendariumData
{
    public interface IPlanetRepository
    {
        public void SavePlanet(Planet planet);
        public Planet GetPlanet();
    }
}