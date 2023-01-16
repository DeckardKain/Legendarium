
namespace LegendariumWorld
{
    public class Path
    {
        public int Id { get; set; }
        public double Length { get; set; }        
        public int? Width { get; set; }
        public string? Terrain { get; set; }
        public string? Elevation { get; set; }

        public enum TerrainType
        {
            Rocky,
            Wet,
            Smooth,
            Jagged,
            Atmosphere, // Atmosphere technologies as a skill name
            Closterphobic,
            Gravity,
            Thick,
            Narrow,
            Bouyant,
            Flooded,
            Scorched,
            Slippery,
            Rubble,
            Tunnel,
            Hallway
        }



    }
}
