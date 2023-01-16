using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendariumLife
{
    public class Deck
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public List<CardOfLegend> Cards { get; set; }

    }
}
