using LegendariumAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendariumData
{
    public class AdventureRepository : IAdventureRepository
    {
        private readonly LegendariumDbContext _context;

        public AdventureRepository(LegendariumDbContext context)
        {
            _context = context;
        }

        public void NewAdventure(AdventureOfLegend adventure)
        {
            _context.Adventure.Add(adventure);
            _context.SaveChanges();
        }

        public List<AdventureOfLegend> GetAdventuresByPlayerId(int playerId)
        {
            var adventures = _context.Adventure.Where(x => x.PlayerId == playerId).ToList();
            return adventures;
        }
    }
}
