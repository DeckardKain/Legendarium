
namespace LegendariumWorld
{
    public class Location
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        public int ParentLocationId { get; set; }
        public int PlayerId { get; set; }
        public string? Name { get; set; }
        public string Type { get; set; }
        public string? Img { get; set; }
        public bool IsOnSurface { get; set; }        
        public string Biome { get; set; }
        public int Size { get; set; }
        public int CoordinateX1 { get; set; }
        public int CoordinateX2 { get; set; }
        public int CoordinateY1 { get; set; }
        public int CoordinateY2 { get; set; }
        public int CoordinateZ1 { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public enum BiomeType
        {
            Forest,
            Jungle,
            Grasslands,
            Mountain,
            Hills,
            Valley,
            BadLands,            
            Arctic,
            Desert,
            Marshland,
            Swamp,            
            Volcanic,            
            Ocean,            
            Riverlands,
            Tropical
            //Underground
        }

        public enum UnderGroundBiomes
        {
            Massive,
            Lake,
            River,
            Crystal,
            Rocky,
            Poisonous,
            Murky
        }
        public enum DungeonBiomes
        {
            Cave
        }

    }
}
