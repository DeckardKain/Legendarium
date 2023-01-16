using LegendariumLife;

namespace LegendariumWorld
{
    public class TaskOfLegend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
        public string Difficulty { get; set; }
        public List<Character> Characters { get; set; }
        public string Output { get; set; }


    }
}
