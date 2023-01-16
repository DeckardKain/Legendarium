using LegendariumLife;

namespace LegendariumData
{
    public interface ICardRepository
    {
        void SaveCard(CardOfLegend card);
        void DeleteCard(CardOfLegend card);
    }
}