

using LegendariumWorld;

namespace LegendariumData
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly LegendariumDbContext _context;

        public PlayerRepository(LegendariumDbContext context)
        {
            _context = context;
        }
        public void CreateNewPlayer(Player player)
        {
            _context.Player.Add(player);
            _context.SaveChanges();
        }

        public void UpdatePlayerPower(int id,int powerAmount) 
        {
            var player = _context.Player.Find(id);
            if(!(player == null)) 
            {
                player.Power += powerAmount;
            }            
            _context.SaveChanges();
            // Log power change.
        }

        public void UpdatePlayerVision(int id, int visionAmount)
        {
            var player = _context.Player.Find(id);
            if (!(player == null))
            {
                player.Vision += visionAmount;
            }
            _context.SaveChanges();
            // Log vision change.
        }

        public void AddPlayerLocation(int playerId, int locationId)
        {
            var playerLocation = new Player_Location()
            {
                PlayerId = playerId,
                LocationId = locationId
            };
            _context.PlayerLocations.Add(playerLocation);
            _context.SaveChanges();
        }

        public bool PlayerLocationExists(int playerId, int locationId)
        {
            var exists = _context.PlayerLocations.Any(x => x.PlayerId == playerId && x.LocationId == locationId);
            return exists;
        }

        public List<Location> GetPlayerKnownLocations(int playerId)
        {
            var playerLocations = new List<Location>();
            var locations = new List<Player_Location>();

            try
            {
                locations = _context.PlayerLocations.Where(x => x.PlayerId == playerId).ToList();
                foreach (Player_Location playerLocation in locations)
                {
                    var location = _context.Location.FirstOrDefault(x => x.Id == playerLocation.LocationId);
                    playerLocations.Add(location);
                }
            }
            catch (Exception)
            {
                return playerLocations;
            }
            return playerLocations;
        }

    }
}
