namespace LegendariumUI.Services
{
    public interface IPowerService
    {
        event Action OnChange;
        int Power { get; set; }
        void PowerValueChange(int amount);
        Task GetPower();
    }
}
