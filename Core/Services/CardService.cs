using Domain.Entities;
using Mapper.Mapper;
using Microsoft.AspNetCore.Http;
using Repositories;
using Services.Bases;
using Services.Impl.Card;
using System.Threading.Tasks;

namespace Services
{
    public class CardService :BaseHandler, ICardService
    {
        private readonly ICardRepository cardRepository;
        private readonly ICardTypeRepository cardTypeRepository;
        public CardService(ICardRepository cardRepository,ICardTypeRepository cardTypeRepository,IMapperr mapper,IHttpContextAccessor httpContextAccessor):base(httpContextAccessor, mapper)
        {
            this.cardRepository = cardRepository;
            this.cardTypeRepository = cardTypeRepository;
        }
 
        public void CashbackToBalance(double cashbackAmount)
        {
            throw new NotImplementedException();
        }
        public async Task<List<CardDto>> GetCardByUserId()
        {
            List<Card> cards = (List<Card>)await cardRepository.GetAllAsync(c => c.UserId == Guid.Parse(userId));
            List<CardDto> cardDtos = new List<CardDto>();
            foreach (Card cardDto in cards) {
                CardDto card = mapper.Map<CardDto, Domain.Entities.Card>(cardDto);
                card.CardTypeName = (await cardTypeRepository.GetAsync(ct => ct.Id == cardDto.CardTypeId)).Name;
                cardDtos.Add(card);

            }
            return cardDtos;
        }

        public Task<CardDto> GetCardById(int cardId)
        {
            throw new NotImplementedException();
        }

        public async Task<CardDto> CreateCard(CardDtoIU request)
        {
            Card card = mapper.Map<Card,CardDtoIU>(request);
            card.CardNumber = GenerateCardNumber();
            card.Cvv = generateCvv();
            card.ExpiryDate = GenerateExpiryDate();
            card.CashbackBalance = 0;
            card.MonthltSpent = 0;
            
            await cardRepository.AddAsync(card);

            CardDto cardDto = mapper.Map<CardDto, Domain.Entities.Card>(card);
            cardDto.CardTypeName = (await cardTypeRepository.GetAsync(ct => ct.Id == card.CardTypeId)).Name;

            await cardRepository.SaveChangesAsync();
            return cardDto;

        }

        public void DeleteCard(int cardId)
        {
            throw new NotImplementedException();
        }



        public void IncreaseBalance(string cardNumber, double balance)
        {
            throw new NotImplementedException();
        }

     
        public void Payment(double amount)
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
