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

        public AccountsService(GigaBankLabContext context)
        {
            this.context = context;
        }

        public async Task<(Account current, Account percent)> CreateDepositAccounts(Deposit deposit, DepositContractDTO depositContractDTO)
        {
            var accountId = await GetAccountsNumber(depositContractDTO.ClientId);
            var current = new Account()
            {
                Number = Account.GenerateNumber(AccountConstants.CurrentAccountCode, depositContractDTO.ClientId, accountId),
                ClientId = depositContractDTO.ClientId,
                CurrencyId = deposit.CurrencyId,
                Type = AccountType.Passive
            };
            var percent = new Account()
            {
                Number = Account.GenerateNumber(AccountConstants.PercentAccountCode, depositContractDTO.ClientId, accountId),
                ClientId = depositContractDTO.ClientId,
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
