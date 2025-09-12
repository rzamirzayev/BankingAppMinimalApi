namespace Application.Features.Card.Command.CashbackToBalance
{
    public class CashbackToBalanceCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public double CashbackBalance { get; set; }
    }
}