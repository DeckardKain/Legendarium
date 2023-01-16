using System.ComponentModel.DataAnnotations;

namespace LegendariumLife
{
    public class CardOfLegend
    {
        
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string Bonuses { get; set; }

    }
}
