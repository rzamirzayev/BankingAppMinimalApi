using Domain.Entities;
using Mapper.Mapper;
using Microsoft.AspNetCore.Http;
using Repositories;
using Services.Bases;
using Services.Impl.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TransactionService :BaseHandler,ITransactionService
    {
        private readonly ITranstactionRepository transtactionRepository;

        public TransactionService(ITranstactionRepository transtactionRepository, IHttpContextAccessor httpContextAccessor, IMapperr mapper) : base(httpContextAccessor, mapper)
        {
            this.transtactionRepository = transtactionRepository;
        }

        public async Task CashWithDrawTransaction(CashWithDrawTransactionDto transactionDto, CancellationToken cancellationToken)
        {
            Transaction transaction = new Transaction
            {
                transactionType = TransactionType.CASH_WITHDRAWAL,
                Amount = transactionDto.Amount,
                ReceiverCardId = transactionDto.ReceiverCardId,
                dateTime = DateTime.UtcNow,
                SenderCardId = null

            };
            await transtactionRepository.AddAsync(transaction);
            await transtactionRepository.SaveChangesAsync();
        }

        public async Task PaymentTransaction(PaymentTransactionDto transactionDto, CancellationToken cancellationToken)
        {
            Transaction transaction = new Transaction
            {
                transactionType = TransactionType.PAYMENT,
                Amount = transactionDto.Amount,
                SenderCardId = transactionDto.SenderCardId,
                dateTime = DateTime.UtcNow,
                ReceiverCardId = null
            };
            await transtactionRepository.AddAsync(transaction);
            await transtactionRepository.SaveChangesAsync();
        }

        public async Task TransferTransaction(TransferTransactionDto transactionDto, CancellationToken cancellationToken)
        {
            Transaction transaction = new Transaction
            {
                transactionType = TransactionType.TRANSFER,
                Amount = transactionDto.Amount,
                SenderCardId = transactionDto.SenderCardId,
                ReceiverCardId = transactionDto.ReceiverCardId,
                dateTime = DateTime.UtcNow,
            };
            await transtactionRepository.AddAsync(transaction);
            await transtactionRepository.SaveChangesAsync();
        }
    }
}
