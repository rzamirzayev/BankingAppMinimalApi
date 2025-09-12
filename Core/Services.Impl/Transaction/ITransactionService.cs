using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl.Transaction
{
    public interface ITransactionService
    {
        public Task CashWithDrawTransaction(CashWithDrawTransactionDto transactionDto, CancellationToken cancellationToken);
        public Task PaymentTransaction(PaymentTransactionDto transactionDto, CancellationToken cancellationToken);
        public Task TransferTransaction(TransferTransactionDto transactionDto, CancellationToken cancellationToken);
    }
}
