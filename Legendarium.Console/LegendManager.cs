using LegendariumLife;
using LegendariumPlayer;
using LegendariumWorld;

namespace LegendariumConsole
{
    public class LegendManager
    {
        public static void IntroduceCardSystem()
        {
            Console.WriteLine("Introducing the Card System");
            Console.WriteLine(".");
            Console.WriteLine("..");
            Console.WriteLine("...");
            Console.WriteLine("It is simple.You create cards with your power.");
            Console.WriteLine("Use those cards to gain control of characters");
            Console.WriteLine("Acquisition - New Card");
            //CardManager.CreateCards();
            //var card = CardManager.Cards.FirstOrDefault();
            //Console.WriteLine($"Name: {card.Name}");
            //Console.WriteLine($"Action: {card.Action}");
            //Console.WriteLine($"Bonuses: {card.Bonuses[0]}");
            //Console.WriteLine($"Bonuses: {card.Bonuses[1]}");
            Console.WriteLine("...");
            Console.WriteLine("Press any key to collect!");
            Console.ReadKey();
            Console.WriteLine("Collected!");
        }
    }
}
