using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendariumWorld
{
    public class Barrier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? HP { get; set; }
        public bool IsPassable { get; set; }
        public string Type { get; set; }
        public string Weaknesses { get; set; }
        public string Strengths { get; set; }
        public int? Height { get; set; }


        public enum BarrierTypes
        {
            Water,
            Rock,
            Ice,
            Gap,
            DropOff,
            Wall,
            Custom
        };

    }
}
