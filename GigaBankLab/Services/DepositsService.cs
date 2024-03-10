using GigaBankLab.Data;
using GigaBankLab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GigaBankLab.Services
{
    public class DepositsService
    {
        private readonly GigaBankLabContext context;
        private readonly CurrentDateService dateService;
        private readonly AccountsService accountsService;
        private readonly TransactionsService transactionsService;

        public DepositsService(GigaBankLabContext context, CurrentDateService dateService, AccountsService accountsService, TransactionsService transactionsService)
        {
            this.context = context;
            this.dateService = dateService;
            this.accountsService = accountsService;
            this.transactionsService = transactionsService;
        }

        public async Task CloseDepositContract(int depositContractId)
        {

            var depositContract = await context.DepositContracts
                .Include(dc => dc.CurrentAccount)
                .Include(dc => dc.PercentAccount)
                .SingleAsync(dc => dc.Id == depositContractId);

            var cash = await context.Accounts.FindAsync(1);
            var fund = await context.Accounts.FindAsync(2);

            var current = depositContract.CurrentAccount;
            var currentSum = depositContract.Sum;

            await transactionsService.CreateTransaction(fund, current, currentSum);
            await transactionsService.CreateTransaction(current, cash, currentSum);

            cash.Credit += currentSum;

            var percent = depositContract.PercentAccount;
            var percentSum = percent.Balance;

            if (percentSum > 0)
            {
                await transactionsService.CreateTransaction(percent, cash, percentSum);

                cash.Credit += percentSum;
            }

            depositContract.IsClosed = true;
            depositContract.CloseDate = await dateService.GetTodayAsync();
            await context.SaveChangesAsync();

        }

        public async Task CreateDepositContract(DepositDTO depositDto)
        {
            if (depositDto.Amount <= 0)
            {
                throw new ArgumentException("Invalid amount");
            }

            using var transaction = await context.Database.BeginTransactionAsync();

            var currentDate = await dateService.GetTodayAsync();
            var deposit = await context.Deposits.FindAsync(depositDto.DepositId);
            var duration = deposit!.Duration;
            var endDate = currentDate.AddDays(duration);

            var (current, percent) = await accountsService.CreateDepositAccounts(deposit, depositDto);

            var cash = await context.Accounts.FindAsync(1);
            var fund = await context.Accounts.FindAsync(2);

            cash!.Debit += depositDto.Amount;

            await transactionsService.CreateTransaction(cash!, current, depositDto.Amount);
            await transactionsService.CreateTransaction(current, fund!, depositDto.Amount);

            var depositContract = new DepositContract()
            {
                OpenDate = currentDate,
                CloseDate = endDate,
                PercentAccount = percent,
                CurrentAccount = current,
                Deposit = deposit,
                ClientId = depositDto.ClientId,
                Sum = depositDto.Amount,
            };

            await context.AddAsync(depositContract);
            await context.SaveChangesAsync();

            await transaction.CommitAsync();
        }

        public async Task CalculatePercent()
        {
            var date = await dateService.GetTodayAsync();
            var openDepositContracts = await context.DepositContracts
                .Where(dc => !dc.IsClosed && dc.CloseDate > date && dc.OpenDate <= date)
                .Include(dc => dc.PercentAccount)
                .Include(dc => dc.CurrentAccount)
                .Include(dc => dc.Deposit)
                .ToListAsync();

            var fund = await context.Accounts.FindAsync(2);

            foreach (var dc in openDepositContracts)
            {
                var amount = dc.CurrentAccount!.Debit;
                var percents = amount * (decimal)(dc.Deposit!.Percent / 100 / 365);
                await transactionsService.CreateTransaction(fund!, dc.PercentAccount!, percents);
            }

            await context.SaveChangesAsync();
        }
    }
}
