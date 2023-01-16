using Blazored.LocalStorage;
using LegendariumData;
using LegendariumWorld;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LegendariumUI.Repositories.Authentication
{
    public class AuthRepository : IAuthRepository
    {
        private readonly LegendariumDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILocalStorageService _localStorageService;
        private string Secret = "TGV0VGhvc2VXaG9IYXZlV2lsbGVkR2l2ZVVwRGVzaXJl";

        public AuthRepository(LegendariumDbContext context, IConfiguration configuration, ILocalStorageService localStorageService)
        {
            _context = context;
            _configuration = configuration;
            this._localStorageService = localStorageService;
        }
        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var player = await _context.Player.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

            if (player == null)
            {
                response.Success = false;
                response.Message = "Error: Email Not Found.";
            }
            else if (!VerifyPasswordHash(password, player.PasswordHash, player.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password.";
            }
            else
            {
                response.Data = CreateToken(player);
                await _localStorageService.SetItemAsync<string>("exp", DateTime.Now.AddDays(1).Ticks.ToString());
                await _localStorageService.SetItemAsync<string>("usrid", player.Id.ToString());
                await _localStorageService.SetItemAsync<string>("usrnm", player.UserName);
                response.Success = true;
                response.Message = "Login Successful.";
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(Player player, string password)
        {
            if (await PlayerExists(player.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "Error: Player Already Exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            player.PasswordHash = passwordHash;
            player.PasswordSalt = passwordSalt;

            _context.Player.Add(player);
            await _context.SaveChangesAsync();            

            return new ServiceResponse<int> { Data = player.Id, Success = true, Message = "Info: New Player Has Been Added." };
        }


        public async Task<bool> PlayerExists(string email)
        {
            if (await _context.Player.AnyAsync(u => u.Email.ToLower().Equals(email)))
            {
                return true;
            }

            return false;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)handler.ReadJwtToken(token);
                if(jwtToken == null)
                {
                    return null;
                }

                byte[] key = Convert.FromBase64String(Secret);
                
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                SecurityToken securityToken;
                ClaimsPrincipal principal = handler.ValidateToken(token, parameters, out securityToken);
                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ValidateToken(string token)
        {
            string username = null;

            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
            {
                return null;
            }

            ClaimsIdentity identity = null;

            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }

            Claim claim = identity.FindFirst(ClaimTypes.Name);
            username = claim.Value;

            return username;
        }
        private string CreateToken(Player player)
        {
            byte[] key = Convert.FromBase64String(Secret);

            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, player.Id.ToString()),
                    new Claim(ClaimTypes.Name, player.UserName),
                    new Claim(ClaimTypes.Role, "Player"),
                    new Claim(JwtRegisteredClaimNames.Sub, player.Email),
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);

            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.NameIdentifier, player.Id.ToString()),
            //    new Claim(ClaimTypes.Name, player.UserName),
            //    new Claim(ClaimTypes.Role, "Player"),
            //    new Claim(JwtRegisteredClaimNames.Sub, player.Email),
            //};

            //var token = new JwtSecurityToken(_configuration["AppSettings:Issuer"],
            //   _configuration["AppSettings:Audience"],
            //   claims,
            //   expires: DateTime.Now.AddDays(1),
            //   signingCredentials: credentials
            //   );

            //var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(_configuration["AppSettings:Issuer"],
            //   _configuration["AppSettings:Audience"],
            //   claims,
            //   expires: DateTime.Now.AddDays(1),
            //   signingCredentials: credentials
            //   );


            

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            //    _configuration.GetSection("AppSettings:Token").Value));


            //var tokenKey = _configuration["AppSettings:Token"];
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));


            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //var token = new JwtSecurityToken()
            //{
            //    issuer:"Legendarium",
            //    audience: "Player",
            //    claims: claims,
            //    expires: DateTime.Now.AddDays(1),
            //    signingCredentials: creds)
            //};

            //var token = new JwtSecurityToken(
            //    claims: newClaims,
            //    expires: DateTime.Now.AddDays(1),
            //    signingCredentials: creds,
            //    issuer:"Legendarium",
            //    audience: "Players"
            //);

            //token = handler.ReadJwtToken(idToken.Replace("\0",""));

            //var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            //var updatedJWT = new JwtSecurityTokenHandler().ReadJwtToken(jwt.Replace("\"", ""));
            //var jwt2 = new JwtSecurityTokenHandler().WriteToken(updatedJWT);

            //return jwt;
        }

    }
}
