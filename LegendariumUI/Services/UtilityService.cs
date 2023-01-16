using Blazored.LocalStorage;
using LegendariumData;
using LegendariumLife;
using LegendariumWorld;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace LegendariumUI.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly LegendariumDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalStorageService _storageService;
        private readonly IPlayerRepository _playerRepository;

        public UtilityService(LegendariumDbContext context, IHttpContextAccessor httpContextAccessor,ILocalStorageService StorageService,IPlayerRepository playerRepository)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _storageService = StorageService;
            _playerRepository = playerRepository;
        }
        public async Task<Player> GetPlayer()
        {
            int userId = 0;

            try
            {
                userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var authToken = await _storageService.GetItemAsStringAsync("authToken");
                var identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                //userId = int.Parse(identity.Claims.First<Claim>().Value);
                //userId = await _storageService.GetItemAsync<int>("usrid");

            }
            catch(Exception)
            {
                return new Player { };
            }
            
            var user = await _context.Player.FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public async Task<int> GetPlayerId()
        {
            var authToken = await _storageService.GetItemAsStringAsync("authToken");
            var identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
            var userId = int.Parse(identity.Claims.First<Claim>().Value);

            return userId;
        }

        public async Task<string> GetPlayerToken()
        {
            var token = await _storageService.GetItemAsStringAsync("authToken");
            return token;
        }

        public List<CardOfLegend> GetPlayerCards(int playerId) 
        {            
            var cards = new List<CardOfLegend>();
            var card = new CardOfLegend();

            card = CardManager.CreateCards(playerId);

            cards.Add(card);

            return cards;
        }

        public void AddPlayerLocations(int playerId, List<Location> locations)
        {
            foreach(Location location in locations)
            {
                if (!_playerRepository.PlayerLocationExists(playerId, location.Id))
                {
                    _playerRepository.AddPlayerLocation(playerId, location.Id);
                }                               
            }
        }
        public void AddPlayerLocation(int playerId, int locationId)
        {
            if (!_playerRepository.PlayerLocationExists(playerId, locationId))
            {
                _playerRepository.AddPlayerLocation(playerId, locationId);
            }            
        }

        public List<Location> GetPlayerLocations(int playerId)
        {
            var locations = _playerRepository.GetPlayerKnownLocations(playerId);
            return locations;
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

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));

            return claims;
        }




    }
}
