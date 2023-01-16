using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendariumAdventure
{
    public class Supply
    {
        public int Id { get; set; }
        public int AdventureOfLegendId { get; set; }
        public List<ItemOfLegend> Supplies { get; set; } = new List<ItemOfLegend>();

    }
}
