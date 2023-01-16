using LegendariumLife;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendariumWorld
{
    public class EventOfLegend
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public List<Character> Characters { get; set; }
        public string Type { get; set; }
        public string Output { get; set; }
        public string Duration { get; set; }

    }
}
