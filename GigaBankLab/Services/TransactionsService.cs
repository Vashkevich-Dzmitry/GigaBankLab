using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Services
{

        public class TransactionsService
        {
            private readonly GigaBankLabContext context;
            private readonly CurrentDateService dateService;

            public TransactionsService(GigaBankLabContext context, CurrentDateService dateService)
            {
                this.context = context;
                this.dateService = dateService;
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
                await context.AddAsync(transaction);
                await context.SaveChangesAsync();
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
