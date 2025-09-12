using Domain.Entities;
using Mapper.Mapper;
using Microsoft.AspNetCore.Http;
using Repositories;
using Services.Bases;
using Services.Exceptions;
using Services.Impl.Card;
using Services.Impl.Transaction;
using System.Threading.Tasks;

namespace Services
{
    public class CardService :BaseHandler, ICardService
    {
        private readonly ICardRepository cardRepository;
        private readonly ICardTypeRepository cardTypeRepository;
        private readonly ITransactionService transactionService;

        public CardService(ICardRepository cardRepository,ICardTypeRepository cardTypeRepository,ITransactionService transactionService ,IMapperr mapper,IHttpContextAccessor httpContextAccessor):base(httpContextAccessor, mapper)
        {
            this.cardRepository = cardRepository;
            this.cardTypeRepository = cardTypeRepository;
            this.transactionService = transactionService;
        }
 
        public async Task CashbackToBalance(string cardNumber, double cashbackAmount, CancellationToken c)
        {

            Card? card = await cardRepository.GetAsync(c=>c.CardNumber==cardNumber);
            if (card is not null && card.UserId.ToString()==userId)
            {
                if (cashbackAmount < 0) throw new Exception("Cashback amount must be positive");
                if (card.CashbackBalance < cashbackAmount) throw new Exception("Not enough cashback balance");
                card.Balance += cashbackAmount;
                card.CashbackBalance -= cashbackAmount;
                await cardRepository.UpdateAsync(card);
                await cardRepository.SaveChangesAsync();
            }
            else
            {
                throw new CardNotFoundException();
            }
        }
        public async Task<List<CardDto>> GetCardByUserId(CancellationToken cancellationToken)
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


        public async Task<CardDto> CreateCard(CardDtoIU request, CancellationToken cancellationToken)
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
        public async Task IncreaseBalance(string cardNumber, double balance, CancellationToken cancellationToken)
        {
            Card? card = await cardRepository.GetAsync(c => c.CardNumber == cardNumber);
            if (card is not null)
            {

                if (balance < 0) throw new Exception("Balance is must positive");
                card.Balance += balance;
                CashWithDrawTransactionDto transactionDto = new()
                {
                    ReceiverCardId = card.Id,
                    Amount = balance,
                };
                await cardRepository.UpdateAsync(card);
                await transactionService.CashWithDrawTransaction(transactionDto, cancellationToken);

                await cardRepository.SaveChangesAsync();
            }
            else
            {
                throw new CardNotFoundException();
            }
        }


        public async Task Payment(string cardNumber, double amount, CancellationToken cancellationToken)
        {
            Card card = await cardRepository.GetAsync(c => c.CardNumber == cardNumber);
            if (card != null && userId == card.UserId.ToString())
            {
                PaymentTransactionDto paymentTransactionDto = new()
                {
                    SenderCardId = card.Id,
                    Amount = amount,
                };
                double cashbackAmount = amount >= 100 ? (amount * 0.02) : (amount * 0.01);
                await transactionService.PaymentTransaction(paymentTransactionDto, cancellationToken);
                card.CashbackBalance += cashbackAmount;
                card.Balance -= amount;
                card.MonthltSpent += amount;
                await cardRepository.UpdateAsync(card);
                await cardRepository.SaveChangesAsync();

            }
            else
            {
                throw new CardNotFoundException();
            }
        }

        public async Task Transfer(CardOperationDto request, CancellationToken cancellationToken)
        {
            Card card= await cardRepository.GetAsync(c => c.CardNumber == request.MyCardNumber);
            Card receiverCard = await cardRepository.GetAsync(c => c.CardNumber == request.toCardNumber);
            if (card is null || receiverCard is null) throw new CardNotFoundException();
            if (card.UserId.ToString() != userId) throw new UnauthorizedAccessException("You are not authorized to perform this action");
            if (request.amount < 0) throw new Exception("Amount must be positive");
            if (card.Balance < request.amount) throw new Exception("Not enough balance");

            card.Balance -= request.amount;
            receiverCard.Balance += request.amount;
            TransferTransactionDto transferTransactionDto = new()
            {
                SenderCardId = card.Id,
                ReceiverCardId = receiverCard.Id,
                Amount = request.amount,
            };
            await transactionService.TransferTransaction(transferTransactionDto,cancellationToken);
            await cardRepository.UpdateAsync(card);
            await cardRepository.UpdateAsync(receiverCard);
            await cardRepository.SaveChangesAsync();
        }

        public async Task UpdateCardExpiryDate(string cardNumber,CancellationToken cancellationToken)
        {
            Card? card = await cardRepository.GetAsync(c => c.CardNumber == cardNumber);
            if (card is not null && card.UserId.ToString() == userId)
            {
                if (DateTime.ParseExact(card.ExpiryDate, "MM/yy", null) > DateTime.Now)
                {
                    throw new Exception("Card is not expired yet");
                }
                card.ExpiryDate = GenerateExpiryDate();
                await cardRepository.UpdateAsync(card);
                await cardRepository.SaveChangesAsync();
            }
            else
            {
                throw new CardNotFoundException();
            }

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
