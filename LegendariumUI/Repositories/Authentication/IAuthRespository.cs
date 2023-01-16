using LegendariumData;
using LegendariumWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LegendariumUI.Repositories.Authentication
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<int>> Register(Player player, string password);
        Task<bool> PlayerExists(string exists);
        ClaimsPrincipal GetPrincipal(string token);
    }
}
