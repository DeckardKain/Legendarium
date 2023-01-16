using LegendariumAdventure;
using LegendariumLife;
using LegendariumWorld;
using Microsoft.EntityFrameworkCore;

namespace LegendariumData
{
    public class LegendariumDbContext : DbContext
    {

        public DbSet<Planet> Planet { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Discovery> Discovery { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Creature> Creature { get; set; }
        public DbSet<Player> Player { get; set; }        
        public DbSet<AdventureOfLegend> Adventure { get; set; }
        public DbSet<ItemOfLegend> Item { get; set; }
        public DbSet<Supply> Supply { get; set; }
        public DbSet<Player_Location> PlayerLocations { get; set; }
        public DbSet<GameMapItem> GameMapItems { get; set; }
        public DbSet<Resource> Resource { get; set; }

        public LegendariumDbContext(DbContextOptions<LegendariumDbContext> options) : base(options)
        {
            


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameMapItem>()
                .HasKey(k => new { k.Z, k.X, k.Y });


        }

    }
}
