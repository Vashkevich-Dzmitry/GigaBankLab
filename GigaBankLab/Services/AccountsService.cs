using Microsoft.EntityFrameworkCore;
using GigaBankLab.Models;
using GigaBankLab.Data;

namespace GigaBankLab.Services
{
    public class AccountsService
    {
        private readonly GigaBankLabContext _context;

        public AccountsService(GigaBankLabContext context)
        {
            _context = context;
        }

        public async Task<(Account current, Account percent)> CreateDepositAccounts(Deposit deposit, DepositContractDTO depositContractDTO)
        {
            var accountId = await GetAccountsNumber(depositContractDTO.ClientId);
            var current = new Account()
            {
                Number = Account.GenerateNumber(AccountCodes.CurrentAccountCode, depositContractDTO.ClientId, accountId),
                ClientId = depositContractDTO.ClientId,
                CurrencyId = deposit.CurrencyId,
                Type = AccountType.Passive
            };
            var percent = new Account()
            {
                Number = Account.GenerateNumber(AccountCodes.PercentAccountCode, depositContractDTO.ClientId, accountId),
                ClientId = depositContractDTO.ClientId,
                CurrencyId = deposit.CurrencyId,
                Type = AccountType.Passive
            };

            await _context.AddRangeAsync(current, percent);
            await _context.SaveChangesAsync();

            return (current, percent);
        }

        public async Task<(Account current, Account percent)> CreateCreditAccounts(CreditProduct creditProduct, CreditContractDTO creditContractDTO)
        {
            var accountId = await GetAccountsNumber(creditContractDTO.ClientId);
            var current = new Account()
            {
                Number = Account.GenerateNumber(AccountCodes.CreditAccountCode, creditContractDTO.ClientId, accountId),
                ClientId = creditContractDTO.ClientId,
                CurrencyId = creditProduct.CurrencyId,
                Type = AccountType.Active
            };
            var percent = new Account()
            {
                Number = Account.GenerateNumber(AccountCodes.CreditPercentCode, creditContractDTO.ClientId, accountId),
                ClientId = creditContractDTO.ClientId,
                CurrencyId = creditProduct.CurrencyId,
                Type = AccountType.Active
            };

            await _context.AddRangeAsync(current, percent);
            await _context.SaveChangesAsync();

            return (current, percent);
        }

        private Task<int> GetAccountsNumber(int clientId)
        {
            return _context.Accounts.Where(a => a.ClientId == clientId).CountAsync();
        }
    }
}
