namespace Services.Impl.Transaction
{
    public class PaymentTransactionDto
    {
        public int SenderCardId { get; set; }

        public double Amount { get; set; }
    }
}