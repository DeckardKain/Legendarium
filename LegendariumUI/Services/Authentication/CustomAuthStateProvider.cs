using Blazored.LocalStorage;
using LegendariumUI.Repositories.Authentication;
using LegendariumWorld;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Json;

namespace LegendariumUI.Services.Authentication
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storageService;
        private readonly IAuthRepository _authRepository;
        private readonly JwtSecurityTokenHandler _jwtHandler;
        //private readonly HttpClient _http;

        public CustomAuthStateProvider(ILocalStorageService storageService, IAuthRepository authRepository/*, HttpClient http*/)
        {
            _storageService = storageService;
            this._authRepository = authRepository;
            _jwtHandler = new JwtSecurityTokenHandler();
            //_http = http;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userId = await _storageService.GetItemAsStringAsync("usrid");
            var username = await _storageService.GetItemAsStringAsync("usrnm");
            //var authToken = await _storageService.GetItemAsync("authToken");

           
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            
            if (string.IsNullOrEmpty(userId))
            {
                return new AuthenticationState(user);
            }

            //var tokenContent = _jwtHandler.ReadJwtToken(authToken);
            ////var tokenContent = _jwtHandler.ReadJwtToken("eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiemlwZmVsIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiUGxheWVyIiwic3ViIjoicHVibGljcGhpbEBvdXRsb29rLmNvbSIsImV4cCI6MTY3MzczNzk2NywiaXNzIjoiTGVnZW5kYXJpdW0iLCJhdWQiOiJQbGF5ZXJzIn0.h_oEJQExYK59yGXYZcXP9gjoJahKLpNg4GU_Yw9uQZtKXu3SlzjiDW7AQwAe2RY6bZrFFDrLeSVlky93nWKpRA");
            var exp = await _storageService.GetItemAsync<string>("exp");
            if (string.IsNullOrEmpty(exp))
            {
                return new AuthenticationState(user);
            }

            var expTime = Convert.ToInt64(exp);
            if (expTime < DateTime.Now.Ticks)
            {
                await _storageService.RemoveItemsAsync(new List<string> { "exp", "usrnm", "usrid" });
                return new AuthenticationState(user);
            }

            //user = _authRepository.GetPrincipal(authToken);
            List<Claim> claims = new List<Claim>() 
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username),
            };
            identity = new ClaimsIdentity(claims);

            ////identity = new ClaimsIdentity(await GetClaimsAsync(authToken), "jwt");            

            user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            //NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;

        }

        public async Task Login()
        {
            var userId = await _storageService.GetItemAsStringAsync("usrid");
            var username = await _storageService.GetItemAsStringAsync("usrnm");
            var exp = await _storageService.GetItemAsync<string>("exp");
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username),
            };
            var identity = new ClaimsIdentity(claims);
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
