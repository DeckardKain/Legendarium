
namespace LegendariumLife
{
    public class CardManager
    {       

        public static CardOfLegend CreateCards(int id)
        {

            var card = new CardOfLegend()
            {
                PlayerId = id,
                Name = "Dimensional Transmutation",
                Type = "Influence",
                Action = "100% Chance to Acquire a Character",
                Bonuses = "On Aquisition: +100 Power, On Use: +100 Vision"

            };

            return card;          
        }
    }
}
