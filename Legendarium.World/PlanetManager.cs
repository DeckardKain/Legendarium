namespace LegendariumWorld
{
    public class PlanetManager
    {        
        public static Planet CreatePlanet()
        {
            Planet planet = new Planet();

            var random = new Random();            

            var planetMaxSize = 100;
            var planetMinSize = 50;
            
            planet.Size = random.Next(planetMinSize, planetMaxSize);
            planet.Name = "Tiamet";
            planet.Image = "https://semseworld.com/wp-content/uploads/2019/09/semse-planets-screen-2.jpg";

            return planet;
        }




    }
}
