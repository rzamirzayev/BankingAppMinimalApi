namespace Services.Impl.Transaction
{
    public class TransferTransactionDto
    {
        public int SenderCardId { get; set; }
        public int ReceiverCardId { get; set; }
        public double Amount { get; set; }
    }
}