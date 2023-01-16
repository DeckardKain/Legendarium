// See https://aka.ms/new-console-template for more information
using LegendariumConsole;
using LegendariumLife;
using LegendariumPlayer;
using LegendariumWorld;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Welcome to Legendarium!");
Console.WriteLine("This is a console test program to rapidly develop the game systems and features.");
Console.WriteLine("Press any key to get started");
Console.ReadKey();
Console.WriteLine(".");
Console.WriteLine("..");
Console.WriteLine("...");
Console.WriteLine("You must have blacked out");
Console.WriteLine("Because you remember nothing");
Console.WriteLine("Suddenly a purple button blurs into focus");
Console.WriteLine("It says VISION");
Console.WriteLine("Click the Button? Yes or No");
var keypressed = Console.ReadLine();
if (keypressed.Equals("Yes") || keypressed.Equals("yes") || keypressed.Equals("y"))
{
    //var Player = PlayerManager.CreateMaganda();
    //Console.WriteLine($"{Player.Vision} - 100 = {Player.Vision - 100}");
    //Player.Vision -= 100;
    //Console.WriteLine("A clear vision appears before you");
    //Console.WriteLine("You Have Discovered:");
    //Console.WriteLine(".");
    //Console.WriteLine("..");
    //Console.WriteLine("...");
    //Console.WriteLine($"Welcome {Player.Name}! You have {Player.Power} Power & {Player.Vision} Vision");
    //CharacterManager.CreateCharacters();
    //WorldManager.CreateLocations();
    //WorldManager.CreatePaths();

    //var characters = CharacterManager.Characters;
    //var locations = WorldManager.Locations;
    //var paths = WorldManager.Paths;
    //var gates = WorldManager.Gates;

    //Settlement town = new Settlement();
    //Dungeon dungeon = new Dungeon();

    //foreach (var location in locations)
    //{
    //    if (location.GetType() == typeof(Settlement))
    //    {
    //        town = (Settlement)location;
    //    }
    //    if (location.GetType() == typeof(Dungeon))
    //    {
    //        dungeon = (Dungeon)location;
    //    }
    //}



    //Console.WriteLine($"A new town called {town.Name}!");
    //Console.WriteLine("What a great name of a town, dont you think?");
    //Console.WriteLine($"Looks like you arent alone here, there are people in this town. {characters.Count} to be exact");
    Console.WriteLine("Lets see if we can communicate with one so we can find out more inforation on what is going on here");
    Console.WriteLine("Press any key to view the townsfolk");
    Console.ReadKey();
    //foreach (var character in characters)
    //{
    //    Console.WriteLine($"{character.Name} has the following stats:");
    //    Console.WriteLine($"Strength: {character.Strength}");
    //    Console.WriteLine($"Intellect: {character.Intellect}");
    //    Console.WriteLine($"Agility: {character.Agility}");
    //    Console.WriteLine($"Dialect: {character.Dialect}");
    //    Console.WriteLine($"Discernment: {character.Discernement}");
    //    Console.WriteLine($"Stamina: {character.Stamina}");
    //    Console.WriteLine("Press any key to look at the next character");
    //    Console.ReadKey();
    //}
    Console.WriteLine("Now that you have viewed all the people, pick one to interact with, to see if you can communicate your situation");
    Console.WriteLine("Enter the player name now");

    var name = Console.ReadLine();
    var minion = new Character();

    //if (characters.Any(c => c.Name == name))
    //{
    //    minion = characters.FirstOrDefault(c => c.Name == name);
    //    Console.WriteLine($"You can now interact with {name} at a closer level.");
    //    Console.WriteLine("Strange...");
    //    Console.WriteLine(".");
    //    Console.WriteLine("..");
    //    Console.WriteLine("...");
    //    Console.WriteLine($"It doesn't appear you have a mouth to communicate with");
    //    LegendManager.IntroduceCardSystem();
    //}

    Console.WriteLine(".");
    Console.WriteLine("..");
    Console.WriteLine("...");
    Console.WriteLine("Lets put that card to good use");
    //Console.WriteLine($"Press the [C] key to use {CardManager.Cards.FirstOrDefault().Name} on {minion.Name}");
    Console.ReadKey();
    Console.WriteLine("Success!");
    //Player.Power += 100;
    //Console.WriteLine($"Power: {Player.Power}");
    //Player.Characters.Add(minion);
    Console.WriteLine("You have unlocked the Adventure Menu!");
    Console.WriteLine("New Adventure - Press [N]");
    Console.WriteLine("Adventures In Progress - Press [A]");
    var keypressed1 = Console.ReadLine();
    //if (keypressed1.Equals("N") || keypressed1.Equals("n"))
    //{
    //    Console.WriteLine("New Adventure");
    //    Console.WriteLine("Select your characters");
    //    foreach(var character in Player.Characters)
    //    {
    //        Console.WriteLine(character.Name + " Press 1");
    //    }
    //    Console.ReadKey();

    //    Console.WriteLine("Where we going?");
    //    Player.Locations = WorldManager.Locations;
    //    var allPaths = WorldManager.Paths;
    //    foreach(var location in Player.Locations)
    //    {
    //        Console.WriteLine($"Name: {location.Name} Type: {location.Biome}");
    //        Console.WriteLine("Connected Paths:");
    //        Console.WriteLine($"{allPaths.Find(x => x.Id == location.Id).Name}");
    //    }
    Console.ReadKey();


}










