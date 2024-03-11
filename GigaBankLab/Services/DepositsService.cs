using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Services
{
    public class DepositsService
    {
        private readonly GigaBankLabContext _context;
        private readonly CurrentDateService _dateService;
        private readonly AccountsService _accountsService;
        private readonly TransactionsService _transactionsService;

        public DepositsService(GigaBankLabContext context, CurrentDateService dateService, AccountsService accountsService, TransactionsService transactionsService)
        {
            _context = context;
            _dateService = dateService;
            _accountsService = accountsService;
            _transactionsService = transactionsService;
        }

        // Возвращаем деньги
        public async Task CloseDepositContract(int depositContractId)
        {
            var depositContract = await _context.DepositContracts
                .Include(dc => dc.CurrentAccount)
                .Include(dc => dc.PercentAccount)
                .SingleAsync(dc => dc.Id == depositContractId); // находим нужный депозит

            var cash = await _context.Accounts.FindAsync(1); // находим счёт кассы
            var fund = await _context.Accounts.FindAsync(2); // находим счёт фонда

            var current = depositContract.CurrentAccount;
            var currentSum = depositContract.Sum;

            await _transactionsService.CreateTransaction(fund!, current!, currentSum, await _dateService.GetBankDayAsync()); // переводим деньги с фонда на счёт
            await _transactionsService.CreateTransaction(current!, cash!, currentSum, await _dateService.GetBankDayAsync()); // переводим деньги с основного счёта на счёт кассы


            cash!.Credit += currentSum; // симулирую выдачу вклада в кассе


            var percent = depositContract.PercentAccount;
            var percentSum = percent!.Balance;

            if (percentSum > 0)
            {
                await _transactionsService.CreateTransaction(percent, cash, percentSum, await _dateService.GetBankDayAsync()); // переводим деньги с процентного счёта на счёт кассы

                cash!.Credit += percentSum; // симулирую выдачу процентов по вкладу в кассе
            }

            depositContract.IsClosed = true;
            await _context.SaveChangesAsync();

        }

        public async Task RevokeDepositContract(int depositContractId)
        {
            var depositContract = await _context.DepositContracts
                .Include(dc => dc.CurrentAccount)
                .Include(dc => dc.PercentAccount)
                .SingleAsync(dc => dc.Id == depositContractId); // находим нужный депозит

            var cash = await _context.Accounts.FindAsync(1); // находим счёт кассы
            var fund = await _context.Accounts.FindAsync(2); // находим счёт фонда

            var current = depositContract.CurrentAccount;
            var currentSum = depositContract.Sum;

            await _transactionsService.CreateTransaction(fund!, current!, currentSum, await _dateService.GetTodayAsync()); // переводим деньги с фонда на счёт
            await _transactionsService.CreateTransaction(current!, cash!, currentSum, await _dateService.GetTodayAsync()); // переводим деньги с основного счёта на счёт кассы


            cash!.Credit += currentSum; // симулирую выдачу вклада в кассе


            var percent = depositContract.PercentAccount;
            var percentSum = percent!.Balance;

            if (percentSum > 0)
            {
                await _transactionsService.CreateTransaction(percent, fund!, percentSum, await _dateService.GetTodayAsync()); // переводим деньги с процентного счёта на счёт фонда
            }

            depositContract.IsClosed = true;
            depositContract.CloseDate = await _dateService.GetTodayAsync();

            await _context.SaveChangesAsync();

        }

        // Получаем деньги, создаём 2 счёта
        public async Task CreateDepositContract(DepositContractDTO depositContractDTO)
        {
            if (depositContractDTO.Amount <= 0) // проверка на наличие денег в фонде, к сожалению, отсутствует
            {
                throw new ArgumentException("Invalid amount");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            var currentDate = await _dateService.GetTodayAsync();
            var deposit = await _context.DepositProducts.FindAsync(depositContractDTO.DepositProductId);
            var duration = deposit!.Duration;
            var endDate = currentDate.AddMonths(duration);

            var (current, percent) = await _accountsService.CreateDepositAccounts(deposit, depositContractDTO);

            var cash = await _context.Accounts.FindAsync(1);
            var fund = await _context.Accounts.FindAsync(2);

            cash!.Debit += depositContractDTO.Amount;

            await _transactionsService.CreateTransaction(cash!, current, depositContractDTO.Amount, await _dateService.GetTodayAsync());
            await _transactionsService.CreateTransaction(current, fund!, depositContractDTO.Amount, await _dateService.GetTodayAsync());

            var depositContract = new DepositContract()
            {
                OpenDate = currentDate,
                CloseDate = endDate,
                PercentAccountId = percent.Id,
                CurrentAccountId = current.Id,
                DepositProductId = depositContractDTO.DepositProductId,
                ClientId = depositContractDTO.ClientId,
                Sum = depositContractDTO.Amount,
            };

            await _context.AddAsync(depositContract);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
        }

        public async Task CalculatePercent()
        {
            var date = await _dateService.GetBankDayAsync();
            var openDepositContracts = await _context.DepositContracts
                .Where(dc => !dc.IsClosed && dc.CloseDate.Date >= date.Date && dc.OpenDate <= date.Date)
                .Include(dc => dc.PercentAccount)
                .Include(dc => dc.CurrentAccount)
                .Include(dc => dc.DepositProduct)
                .ToListAsync();

            var cash = await _context.Accounts.FindAsync(1);
            var fund = await _context.Accounts.FindAsync(2);

            foreach (var dc in openDepositContracts)
            {
                var amount = dc.CurrentAccount!.Debit;
                var percents = amount * (decimal)(dc.DepositProduct!.Percent / 100 / ((((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0) ? 1 : 0) + 365));
                await _transactionsService.CreateTransaction(fund!, dc.PercentAccount!, percents, await _dateService.GetBankDayAsync());

                var openDay = dc.OpenDate.Day;
                var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                var currentDay = date.Day;

                if (dc.DepositProduct.IsPartialWithdrawal && (currentDay == openDay || (openDay > daysInMonth && currentDay == daysInMonth)))
                {
                    var percent = dc.PercentAccount;
                    var percentSum = percent!.Balance;

                    await _transactionsService.CreateTransaction(percent!, cash!, percentSum, await _dateService.GetBankDayAsync());

                    cash!.Credit += percentSum; // симулирую выдачу процентов по вкладу в кассе
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
