using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendariumWorld
{
    public class Building
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Type { get; set; }
        public string? Cost { get; set; }
        public string? Cost2 { get; set; }
        public string? Cost3 { get; set; }
        public string? Cost4 { get; set; }
        public double Size { get; set; }
    }
}
