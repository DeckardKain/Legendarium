using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace LegendariumUI.Services.Authentication
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storageService;

        public CustomAuthStateProvider(ILocalStorageService storageService)
        {
            _storageService = storageService;           
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            string exp;
            string userId;
            string userName;
            string authToken;

            try
            {
                userId = await _storageService.GetItemAsStringAsync("usrid");
                userName = await _storageService.GetItemAsStringAsync("usrnm");
                authToken = await _storageService.GetItemAsStringAsync("authToken");
                exp = await _storageService.GetItemAsync<string>("exp");
            }
            catch
            {
                return new AuthenticationState(user);
            }

            var expTime = Convert.ToInt64(exp);
            
            if (expTime < DateTime.Now.Ticks)
            {
                await _storageService.RemoveItemsAsync(new List<string> { "exp", "usrnm", "usrid" });
                return new AuthenticationState(user);
            }

           
            List<Claim> claims = new List<Claim>() 
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userName),
            };

            identity = new ClaimsIdentity(claims, "jwt");                  

            user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;

        }

        public async Task Login()
        {
            var userId = await _storageService.GetItemAsStringAsync("usrid");
            var username = await _storageService.GetItemAsStringAsync("usrnm");
            //var exp = await _storageService.GetItemAsync<string>("exp");
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username),
            };
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }

        //private byte[] ParseBase64WithoutPadding(string base64)
        //{
        //    switch (base64.Length % 4)
        //    {
        //        case 2:
        //            base64 += "==";
        //            break;
        //        case 3:
        //            base64 += "=";
        //            break;
        //    }

        //    return Convert.FromBase64String(base64);
        //}

        //private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        //{
        //    var payload = jwt.Split('.')[1];
        //    var jsonBytes = ParseBase64WithoutPadding(payload);
        //    var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        //    var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));

        //    return claims;
        //}

        //private async Task<IEnumerable<Claim>> GetClaimsAsync(string jwt)
        //{
        //    var tokenContent = _jwtHandler.ReadJwtToken(jwt);
        //    var claims = tokenContent.Claims.ToList();
        //    return claims;
        //}

    }
}
