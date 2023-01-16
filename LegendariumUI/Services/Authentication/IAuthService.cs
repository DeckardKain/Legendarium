using LegendariumData;
using LegendariumUI.Models.Authentication;

namespace LegendariumUI.Services.Authentication
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(PlayerLogin request);
        Task<ServiceResponse<int>> Register(PlayerRegister request);
        Task<ServiceResponse<bool>> VerifyToken();
    }
}
