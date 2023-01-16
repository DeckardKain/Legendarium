using System.Drawing;
using System.Reflection;

namespace LegendariumLife
{
    public class Character
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }        
        public int PathId { get; set; }
        public Deck Deck { get; set; }
        public string Type { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Dialect { get; set; }
        public int Discernement { get; set; }
        public int Stamina { get; set; }
        public int Dexterity { get; set; }
        public List<Relationship> Relationships { get; set; }
        public string Rank { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Energy { get; set; }
        public enum Types
        {
            Humanoid,
            Reptilian,
            Fungaloid,
            Plantanoid,
            Avian,
            Insectoid,
            Amphibian
        }

    }
}