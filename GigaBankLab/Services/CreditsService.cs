using GigaBankLab.Data;
using GigaBankLab.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GigaBankLab.Services
{
    public class CreditsService
    {
        private readonly GigaBankLabContext _context;
        private readonly CurrentDateService _dateService;
        private readonly AccountsService _accountsService;
        private readonly TransactionsService _transactionsService;

        private readonly int _creditCardNumberLength = 16;
        private readonly int _creditCardPINLength = 4;

        public CreditsService(GigaBankLabContext context, CurrentDateService dateService, AccountsService accountsService, TransactionsService transactionsService)
        {
            _context = context;
            _dateService = dateService;
            _accountsService = accountsService;
            _transactionsService = transactionsService;
        }

        public async Task CreateCreditContract(CreditContractDTO creditContractDTO)
        {
            if (creditContractDTO.Amount <= 0) // проверка на наличие денег в фонде, к сожалению, отсутствует
            {
                throw new ArgumentException("Invalid amount");
            }

            var currentDate = await _dateService.GetTodayAsync();
            var credit = await _context.Credits.FindAsync(creditContractDTO.CreditId);
            var duration = credit!.Duration;
            var endDate = currentDate.AddMonths(duration);

            var (current, percent) = await _accountsService.CreateCreditAccounts(credit, creditContractDTO);

            var cash = await _context.Accounts.FindAsync(1);
            var fund = await _context.Accounts.FindAsync(2);

            await _transactionsService.CreateTransaction(fund!, current, creditContractDTO.Amount, await _dateService.GetTodayAsync());
            await _transactionsService.CreateTransaction(current, cash!, creditContractDTO.Amount, await _dateService.GetTodayAsync()); //???

            cash!.Credit += creditContractDTO.Amount; // симулирую выдачу вклада в кассе

            var creditContract = new CreditContract()
            {
                CurrentAccountId = current.Id,
                PercentAccountId = percent.Id,
                ClientId = creditContractDTO.ClientId,
                CreditId = creditContractDTO.CreditId,
                OpenDate = currentDate,
                CloseDate = endDate,
                Sum = creditContractDTO.Amount,
                IsClosed = false,
                CreditCardNumber = GenerateRandomNumberWithLength(_creditCardNumberLength),
                CreditCardPIN = GenerateRandomNumberWithLength(_creditCardPINLength)
            };

            await _context.AddAsync(creditContract);
            await _context.SaveChangesAsync();
        }


        public List<CreditRepayment> CalculateCreditRepaymentPlan(decimal creditAmount, decimal yearPercent, int months, bool annuity, DateTime startDate)
        {
            yearPercent /= 100;
            var result = new List<CreditRepayment>();
            decimal mainDebth;
            decimal percentDebt = 0;

            if (annuity)
            {
                double monthPercent = (double)yearPercent / 12;
                double coef = monthPercent * Math.Pow(1 + monthPercent, months) / (Math.Pow(1 + monthPercent, months) - 1);
                var totalDebt = creditAmount * (decimal)coef;
                mainDebth = creditAmount / months;
                percentDebt = totalDebt - mainDebth;
            }
            else
            {
                mainDebth = creditAmount / months;
            }

            for (int monthsPassed = 0; monthsPassed < months; monthsPassed++)
            {
                decimal percentDebth = annuity
                  ? percentDebt
                  : (creditAmount - (mainDebth * monthsPassed)) * yearPercent / 12;

                result.Add(new CreditRepayment
                {
                    Date = startDate.AddMonths(monthsPassed),
                    MainDebt = Math.Round(mainDebth, 2),
                    PercentDebt = Math.Round(percentDebth, 2),
                    PaymentSum = Math.Round(mainDebth, 2) + Math.Round(percentDebth, 2)
                });
            }

            return result;
        }

        internal async Task CloseCreditContract(int creditContractId)
        {
            var creditContract = await _context.CreditContracts
                .Include(cc => cc.CurrentAccount)
                .Include(cc => cc.PercentAccount)
                .SingleAsync(cc => cc.Id == creditContractId);

            if (creditContract.PercentAccount!.Balance == 0 && creditContract.CurrentAccount!.Balance == 0)
                creditContract.IsClosed = true;

            await _context.SaveChangesAsync();
        }

        public async Task CalculatePercent()
        {
            var date = await _dateService.GetBankDayAsync();
            var openCreditContracts = await _context.CreditContracts
                .Where(cc => !cc.IsClosed && cc.CloseDate.Date > date.Date)
                .Include(cc => cc.PercentAccount)
                .Include(cc => cc.CurrentAccount)
                .Include(cc => cc.Credit)
                .ToListAsync();

            var cash = await _context.Accounts.FindAsync(1);
            var fund = await _context.Accounts.FindAsync(2);

            foreach (var creditContract in openCreditContracts)
            {
                decimal mainPayment;
                decimal percentPayment;
                var percent = creditContract.Credit!.Percent / 100;

                if (creditContract.Credit.Annuity)
                {
                    var monthPercent = percent / 12;
                    var payment = creditContract.Sum * (decimal)(monthPercent * Math.Pow(1 + monthPercent, creditContract.Credit.Duration) / (Math.Pow(1 + monthPercent, creditContract.Credit.Duration) - 1));
                    mainPayment = creditContract.Sum / creditContract.Credit.Duration;
                    percentPayment = payment - mainPayment;
                }
                else
                {
                    var today = await _dateService.GetBankDayAsync();
                    var periodPassed = GetPeriodPassed(today, creditContract.OpenDate);
                    mainPayment = creditContract.Sum / creditContract.Credit.Duration;
                    percentPayment = (creditContract.Sum - mainPayment * periodPassed) * (decimal)(percent / 12);
                }

                await _transactionsService.CreateTransaction(cash!, creditContract.PercentAccount!, percentPayment, await _dateService.GetBankDayAsync());
                await _transactionsService.CreateTransaction(cash!, creditContract.CurrentAccount!, mainPayment, await _dateService.GetBankDayAsync());
                await _transactionsService.CreateTransaction(creditContract.CurrentAccount!, fund!, mainPayment, await _dateService.GetBankDayAsync());
                await _transactionsService.CreateTransaction(creditContract.PercentAccount!, fund!, percentPayment, await _dateService.GetBankDayAsync());
            }
        }

        private int GetPeriodPassed(DateTime today, DateTime openDate)
        {
            return (today - openDate).Days;
        }

        private string GenerateRandomNumberWithLength(int length)
        {
            Random random = new();

            const string digits = "0123456789";
            
            return new string(Enumerable.Repeat(digits, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
    }
}
