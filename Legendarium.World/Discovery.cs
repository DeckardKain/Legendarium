using LegendariumLife;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendariumWorld
{
    public class Discovery
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Location>? Locations { get; set; }
        public List<Character>? Characters { get; set; }


    }
}
