using GigaBankLab.Data;
using GigaBankLab.Models;
using GigaBankLab.Models.Atm;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GigaBankLab.Services
{
    public class AtmService
    {
        private readonly GigaBankLabContext _context;
        private readonly CurrentDateService _dateService;
        private readonly AccountsService _accountsService;
        private readonly TransactionsService _transactionsService;
        private readonly CreditsService _creditsService;

        public AtmService(GigaBankLabContext context, CurrentDateService dateService, AccountsService accountsService, 
            TransactionsService transactionsService, CreditsService creditsService)
        {
            _context = context;
            _dateService = dateService;
            _accountsService = accountsService;
            _transactionsService = transactionsService;
            _creditsService = creditsService;
        }

        public async Task<int> GetCreditContractIdByCredentials(AtmLoginDTO atmLoginDTO)
        {
            var creditContracts = await _context.CreditContracts
                .Where(cc => cc.CreditCardNumber == atmLoginDTO.CreditCardNumber && cc.CreditCardPIN == atmLoginDTO.CreditCardPIN)
                .ToListAsync();

            if (creditContracts.Count > 0) 
            {
                return creditContracts.First().Id;
            }
            else
            {
                return -1;
            }
        }

        public async Task WithdrawCash(AtmCashWithdrawalDTO atmCashWithdrawalDTO)
        {
            var creditContract = (await _context.CreditContracts
                .Where(cc => cc.Id == atmCashWithdrawalDTO.CreditContractId)
                .Include(cc => cc.CurrentAccount)
                .ToListAsync()).First();

            var account = creditContract.CurrentAccount;

            var cash = await _context.Accounts.FindAsync(1);

            await _transactionsService.CreateTransaction(account!, cash!, atmCashWithdrawalDTO.Sum, await _dateService.GetTodayAsync());

            cash!.Credit += atmCashWithdrawalDTO.Sum; // симулирую выдачу денег банкоматом
        }
    }
}
