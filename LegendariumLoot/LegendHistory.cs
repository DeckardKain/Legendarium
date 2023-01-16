using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendariumLoot
{
    public class LegendHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LegendLoot> History { get; set; }
    }
}
