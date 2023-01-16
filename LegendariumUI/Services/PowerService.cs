using LegendariumData;
using LegendariumWorld;

namespace LegendariumUI.Services
{
    public class PowerService : IPowerService
    {
        private readonly IUtilityService _utilityService;
        private readonly LegendariumDbContext _context;

        private Player Player { get; set; }

        public int Power { get; set; }

        public event Action OnChange;

        public PowerService(IUtilityService utilityService, LegendariumDbContext context)
        {
            _utilityService = utilityService;
            _context = context;
        }

        void PowerChanged() => OnChange.Invoke();
        
        public void PowerValueChange(int amount)
        {
            Power += amount;
            _context.Player.FirstOrDefault(x => x.Id == Player.Id);
            PowerChanged();

        }

        public async Task GetPower()
        {
            var player = await _utilityService.GetPlayer();
            Player = player;
            Power = player.Power;
            PowerChanged();

        }
    }
}
