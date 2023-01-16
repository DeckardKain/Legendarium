using LegendariumLife;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegendariumWorld
{    
    public class GameMapItem
    {    
        public int PlayerId { get; set; }
        public int Z { get; set; }
        public int X { get; set; } 
        public int Y { get; set; }
        public int PowerLevel { get; set; }
        public int ParentLocationId { get; set; }
        public string? Type { get; set; }
        public int TerrainSpeedPenalty { get; set; }
        public bool IsTileMoveable { get; set; }
        public int Stones { get; set; }
        public int Wood { get; set; }
        public int Minerals { get; set; }
        [NotMapped]
        public int MapTile { get; set; }
        [NotMapped]
        public string Weather { get; set; }
        [NotMapped]
        public string Environment { get; set; }
        [NotMapped]
        public int Temperature { get; set; }

    }
}
