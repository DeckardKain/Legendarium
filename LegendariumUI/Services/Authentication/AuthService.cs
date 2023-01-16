using Blazored.LocalStorage;
using LegendariumData;
using LegendariumUI.Models.Authentication;
using LegendariumUI.Repositories.Authentication;
using LegendariumWorld;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace LegendariumUI.Services.Authentication
{
    public class AuthService : IAuthService
    {        
        private readonly IAuthRepository _authRepo;
        private readonly ILocalStorageService _storageService;
        private readonly AuthenticationStateProvider _authenticationState;

        public AuthService(IAuthRepository authRepo, ILocalStorageService storageService, AuthenticationStateProvider authenticationState)
        {        
            _authRepo = authRepo;
            _storageService = storageService;
            _authenticationState = authenticationState;
        }

        public async Task<ServiceResponse<string>> Login(PlayerLogin request)
        {
            var response = await _authRepo.Login(request.Email, request.Password);

            if (response.Success)
            {
                await _storageService.SetItemAsync("authToken", response.Data);
                //await _authenticationState.GetAuthenticationStateAsync();
                await ((CustomAuthStateProvider)_authenticationState).Login();

            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(PlayerRegister request)
        {
            var response = await _authRepo.Register(
                new Player()
                {
                    UserName = request.Username,
                    Email = request.Email,
                    Birthday = request.BirthDay,
                    DateCreated = DateTime.Now,
                    Power = 1000,
                    Vision = 1000,
                    Score = 0
                }, request.Password);

            return response;
        }

        public async Task<ServiceResponse<bool>> VerifyToken()
        {
            var serviceResponse = new ServiceResponse<bool>()
            {
                Success = false,
                Message = "Token could not be validated. Please login again.",
                Data = false
            };

            var state = await _authenticationState.GetAuthenticationStateAsync();

            if(state != null)
            {
                if (state.User.Identity.IsAuthenticated)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Token could not be validated. Please login again.";
                    serviceResponse.Data = false;

                    return serviceResponse;
                }
            }


            return serviceResponse;

            //var tokenHandler = new JwtSecurityTokenHandler();

            ////var authToken = await _storageService.GetItemAsStringAsync("authToken");
            //var authToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6InppcGZlbCIsImV4cCI6MTY3MDk2NTc5MH0.hFmYxzlg2puu6EMlEZWw6mc5QraRexKxtqnDmultyX9S3eEjDwvSQPDxoV7Utukf-BmSaG9fEFljHczfr6-vvQ";

            //TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            //{
            //    ValidateIssuerSigningKey = true,
            //    ValidateLifetime = true
            //};
            //var validationResult = tokenHandler.ValidateTokenAsync(authToken, tokenValidationParameters);

            //var validation = new JwtSecurityTokenHandler().ValidateTokenAsync(authToken,tokenValidationParameters);

            //if (validation.IsCompletedSuccessfully)
            //{
            //    serviceResponse.Success = true;
            //    serviceResponse.Message = "Token validated successfully";
            //    serviceResponse.Data = true;

            //    return serviceResponse;
            //}
            //return serviceResponse;

        }

        IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2:
                    base64 += "==";
                    break;
                case 3:
                    base64 += "=";
                    break;
            }

            return Convert.FromBase64String(base64);
        }

    }
}
