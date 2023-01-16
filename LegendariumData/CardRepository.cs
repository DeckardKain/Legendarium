

using LegendariumLife;

namespace LegendariumData
{
    public class CardRepository : ICardRepository
    {
        private readonly LegendariumDbContext _context;

        public CardRepository(LegendariumDbContext context)
        {
            _context = context;
        }


        public void SaveCard(CardOfLegend card)
        {
            //_context.Card.Add(card);
            _context.SaveChanges();
        }

        public void DeleteCard(CardOfLegend card)
        {
            //_context.Card.Remove(card);
            _context.SaveChanges();
        }
    }
}
