

namespace LegendariumLife
{
    public class Creature
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string? ImageLink { get; set; }
        public string Type { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Dialect { get; set; }
        public int Discernement { get; set; }
        public int Stamina { get; set; }
        public int Dexterity { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public string Rank { get; set; }


        public enum CreatureType
        {
            Creature,
            Mutant,
            Beast,
            Sentient,
            Behemoth,
            Docile,
            Aggressive,
            Monster, // Stop at nothing to accomplish its goals
            Peaceful,
            Loving,
            Prototype,
            Gentle,
            Little
        }

    }
}
