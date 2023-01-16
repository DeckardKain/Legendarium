namespace LegendariumUI.Services
{
    public class VisionService : IVisionService
    {
        private readonly IUtilityService _utilityService;

        public int Vision { get; set; }

        public event Action OnChange;

        public VisionService(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }

        void VisionChanged() => OnChange.Invoke();

        public async Task GetVision()
        {
            var player = await _utilityService.GetPlayer();
            Vision = player.Vision;
            VisionChanged();
        }

        public void VisionValueChange(int amount)
        {
            Vision += amount;
            VisionChanged();
        }
    }
}
