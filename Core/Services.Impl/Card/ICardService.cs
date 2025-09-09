using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl.Card
{
    public interface ICardService
    {
        public  Task<CardDto> CreateCard(CardDtoIU request);
        public Task<List<CardDto>> GetCardByUserId();

        public void DeleteCard(int cardId);

        public Task<CardDto> GetCardById(int cardId);

        public void UpdateCardExpiryDate(int cardId);

        public void Transfer(CardOperationDto request);
        public void IncreaseBalance(string cardNumber,double balance);

        public void Payment(double amount);

        public void CashbackToBalance(double cashbackAmount);

    }
}
