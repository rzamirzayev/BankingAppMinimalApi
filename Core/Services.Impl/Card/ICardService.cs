using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Card
{
    public interface ICardService
    {
        public CardDto CreateCard(CardDtoIU request);
        public List<CardDto> GetAllCards();

        public void DeleteCard(int cardId);

        public CardDto GetCardById(int cardId);

        public void UpdateCardExpiryDate(int cardId);

        public void Transfer(CardOperationDto request);
        public void IncreaseBalance(CardOperationDto request);

        public void Payment(CardOperationDto request);

        public void CashbackToBalance(CardOperationDto request);

    }
}
