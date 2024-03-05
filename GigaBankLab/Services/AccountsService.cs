using GigaBankLab.Models;
using GigaBankLab.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GigaBankLab.Services
{
    public class AccountsService
    {
        private readonly GigaBankLabContext context;
        private readonly CurrentDateService dateService;

        public AccountsService(GigaBankLabContext context, CurrentDateService dateService)
        {
            this.context = context;
            this.dateService = dateService;
        }

        public async Task<(Account current, Account percent)> CreateDepositAccounts(Deposit deposit, DepositDTO depositDto)
        {
            var accountId = await GetAccountsNumber(depositDto.ClientId);
            var current = new Account()
            {
                Number = Account.GenerateNumber(AccountConstants.CurrentAccountCode, depositDto.ClientId, accountId),
                ClientId = depositDto.ClientId,
                CurrencyId = deposit.CurrencyId,
                Type = AccountType.Passive
            };
            var percent = new Account()
            {
                Number = Account.GenerateNumber(AccountConstants.PercentAccountCode, depositDto.ClientId, accountId),
                ClientId = depositDto.ClientId,
                CurrencyId = deposit.CurrencyId,
                Type = AccountType.Passive
            };

            await context.AddRangeAsync(current, percent);
            await context.SaveChangesAsync();

            return (current, percent);
        }

        private Task<int> GetAccountsNumber(int clientId)
        {
            return context.Accounts.Where(a => a.ClientId == clientId).CountAsync();
        }
    }
}
