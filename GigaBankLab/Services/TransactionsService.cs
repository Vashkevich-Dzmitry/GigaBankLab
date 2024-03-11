using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Services
{

        public class TransactionsService
        {
            private readonly GigaBankLabContext _context;
            private readonly CurrentDateService _dateService;

            public TransactionsService(GigaBankLabContext context, CurrentDateService dateService)
            {
                _context = context;
                _dateService = dateService;
            }

            public async Task CreateTransaction(Account from, Account to, decimal amount, DateTime datetime)
            {
                Expenditure(from, amount);
                Income(to, amount);

                var transaction = new Transaction()
                {
                    FromAccount = from,
                    ToAccount = to,
                    Sum = amount,
                    DateTime = datetime
                };
                await _context.AddAsync(transaction);
                await _context.SaveChangesAsync();
            }

            private static void Expenditure(Account account, decimal amount)
            {
                if (account.Type == AccountType.Active)
                {
                    account.Credit += amount;
                }
                else
                {
                    account.Debit += amount;
                }
            }

            private static void Income(Account account, decimal amount)
            {
                if (account.Type == AccountType.Active)
                {
                    account.Debit += amount;
                }
                else
                {
                    account.Credit += amount;
                }
            }
        }
    }
