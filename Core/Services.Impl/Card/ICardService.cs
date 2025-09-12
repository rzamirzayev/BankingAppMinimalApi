namespace Services.Impl.Card
{
    public interface ICardService
    {
        public Task<CardDto> CreateCard(CardDtoIU request,CancellationToken cancellationToken); 
        public Task<List<CardDto>> GetCardByUserId(CancellationToken cancellationToken); 
        public Task UpdateCardExpiryDate(string cardNumber,CancellationToken cancellationToken);

        public Task Transfer(CardOperationDto request,CancellationToken cancellationToken);
        public Task IncreaseBalance(string cardNumber,double balance,CancellationToken cancellationToken);

        public Task Payment(string cardNumber,double amount, CancellationToken cancellationToken);

        public Task CashbackToBalance(string cardNumber,double cashbackAmount,CancellationToken cancellationToken);

    }
}
