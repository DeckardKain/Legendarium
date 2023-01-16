namespace LegendariumUI.Services
{
    public interface IVisionService
    {
        event Action OnChange;
        int Vision { get; set; }
        void VisionValueChange(int amount);
        Task GetVision();
    }
}
