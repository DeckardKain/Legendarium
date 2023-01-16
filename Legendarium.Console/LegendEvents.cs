using LegendariumLife;
using LegendariumLoot;
using LegendariumWorld;
using Path = LegendariumWorld.Path;

namespace LegendariumConsole
{
    public class LegendEvents
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public List<Character> Characters { get; set; }
        public List<Creature>? Creatures { get; set; }
        public Location Location { get; set; }
        public List<Location> AdjacentLocations { get; set; }
        public Path? Path { get; set; }


        public static Character MaxStatTest(List<Character> characters,string type)
        {            

            if (type.Equals("Strength"))
            {
                var strongest = characters.MaxBy(x => x.Strength);
                return strongest;
            }
            if (type.Equals("Intellect"))
            {
                var smartest = characters.MaxBy(x => x.Intellect);
                return smartest;
            }
            if (type.Equals("Dialect"))
            {
                var cleverest = characters.MaxBy(x => x.Dialect);
                return cleverest;
            }
            if (type.Equals("Discernment"))
            {
                var wisest = characters.MaxBy(x => x.Discernement);
                return wisest;
            }
            if (type.Equals("Agility"))
            {
                var agilest = characters.MaxBy(x => x.Agility);
                return agilest;
            }

            return null;

        }

    }
}
