using Domain.Entities;
using Mapper.Mapper;
using Repositories;
using Services.Card;

namespace Services.Implementation
{
    public class CardService : ICardService
    {
        private readonly ICardRepository cardRepository;
        private readonly IMapperr mapper;
        public CardService(ICardRepository cardRepository,IMapperr mapper)
        {
            this.cardRepository = cardRepository;
            this.mapper = mapper;
        }
        public void CashbackToBalance(CardOperationDto request)
        {
            throw new NotImplementedException();
        }

        public CardDto CreateCard(CardDtoIU request)
        {
            Domain.Entities.Card newCard = new()
            {
                CardNumber = GenerateCardNumber(),
                CashbackBalance = 0,
                MonthltSpent = 0,
                Cvv = generateCvv(),
                ExpiryDate = DateTime.Parse(GenerateExpiryDate()),
            };
            
            cardRepository.AddAsync(newCard);

            CardDto cardDto = mapper.Map<CardDto, Domain.Entities.Card>(newCard);
            return cardDto;

        }

        public void DeleteCard(int cardId)
        {
            throw new NotImplementedException();
        }

        public List<CardDto> GetAllCards()
        {
            throw new NotImplementedException();
        }

        public CardDto GetCardById(int cardId)
        {
            throw new NotImplementedException();
        }

        public void IncreaseBalance(CardOperationDto request)
        {
            throw new NotImplementedException();
        }

        public void Payment(CardOperationDto request)
        {
            throw new NotImplementedException();
        }

        public void Transfer(CardOperationDto request)
        {
            throw new NotImplementedException();
        }

        public void UpdateCardExpiryDate(int cardId)
        {
            throw new NotImplementedException();
        }

        private string GenerateCardNumber()
        {
            Random random = new Random();
            string cardNumber = "41697388";
            for (int i = 0; i < 8; i++)
            {
                cardNumber += random.Next(0, 10).ToString();
            }
            return cardNumber;
        }

        private int generateCvv()
        {
            Random random = new Random();
            return random.Next(100, 999);
        }
        private string GenerateExpiryDate()
        {
            DateTime expiry= DateTime.Now.AddYears(3);
            return expiry.ToString("MM/yy");
        }
    }
}
