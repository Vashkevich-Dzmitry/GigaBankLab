using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Services
{
    public class BankOperationsService
    {
        private readonly GigaBankLabContext _context;
        private readonly DepositsService _depositsService;
        private readonly CreditsService _creditsService;
        private readonly CurrentDateService _dateService;

        public BankOperationsService(GigaBankLabContext context, DepositsService depositsService, CurrentDateService dateService, CreditsService creditsService)
        {
            _context = context;
            _depositsService = depositsService;
            _creditsService = creditsService;
            _dateService = dateService;
        }

        public async Task CloseDayAsync()
        {
            await _dateService.NextDay();

            await _depositsService.CalculatePercent();
            await _creditsService.CalculatePercent();

            var date = await _dateService.GetBankDayAsync();

            var depositsToClose = await _context.DepositContracts
                .Where(dc => !dc.IsClosed && dc.CloseDate.Date <= date)
                .ToListAsync();

            foreach (var dc in depositsToClose)
            {
                await _depositsService.CloseDepositContract(dc.Id);
            }

            var creditsToClose = await _context.CreditContracts
                .Where(cc => !cc.IsClosed && cc.CloseDate.Date <= date)
                .ToListAsync();

            foreach (var cc in creditsToClose)
            {
                await _creditsService.CloseCreditContract(cc.Id);
            }
        }
    }
}
