using LegendariumLife;

namespace LegendariumUI.Services
{
    public interface ICardService
    {
        void PlayCard(CardOfLegend card, int playerId, int characterId);
        void CreateCard(int playerId);
        void GetAllCards();
    }
}