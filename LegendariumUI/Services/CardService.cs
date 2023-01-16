using LegendariumData;
using LegendariumLife;

namespace LegendariumUI.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IPowerService _powerService;
        private readonly IVisionService _visionService;

        public CardService(ICardRepository cardRepository, ICharacterRepository characterRepository, IPowerService powerService, IVisionService visionService)
        {
            _cardRepository = cardRepository;
            _characterRepository = characterRepository;
            _powerService = powerService;
            _visionService = visionService;
        }

        public void GetAllCards() 
        {
            //_cardRepository.
        }
        
        public void PlayCard(CardOfLegend card, int playerId, int characterId)
        {
            UseCard(card, playerId, characterId);
            _cardRepository.DeleteCard(card);
        }

        public void CreateCard(int playerId)
        {
            var card = CardManager.CreateCards(playerId);
            _cardRepository.SaveCard(card);
        }

        private void UseCard(CardOfLegend card, int playerId, int characterId)
        {
            switch (card.Name)
            {
                case "Dimensional Transmutation":
                    // Action: 100% chance to acquire character


                    // Bonus - +100 Power
                    _powerService.PowerValueChange(100);

                    // Bonus: +100 Vision
                    _visionService.VisionValueChange(100);
                    break;

            }
        }


    }
}
