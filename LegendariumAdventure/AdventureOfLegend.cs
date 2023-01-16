

using LegendariumLife;

namespace LegendariumAdventure
{
    public class AdventureOfLegend
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string AdventureType { get; set; }
        public string Intention { get; set; }
        public double X1Start { get; set; }
        public double X2End { get; set; }
        public double Y1Start { get; set; }
        public double Y2End { get; set; }
        public double Path { get; set; }
        public List<Character> Characters { get; set; }



    }
}
