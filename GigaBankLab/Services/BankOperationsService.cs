using GigaBankLab.Data;
using GigaBankLab.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaBankLab.Services
{
    public class BankOperationsService
    {
        private readonly GigaBankLabContext context;
        private readonly DepositsService depositContractService;
        private readonly CurrentDateService dateService;

        public BankOperationsService(GigaBankLabContext context, DepositsService depositContractService, CurrentDateService dateService)
        {
            this.context = context;
            this.depositContractService = depositContractService;
            this.dateService = dateService;
        }

        public async Task CloseDayAsync()
        {
            await dateService.NextDay();

            await depositContractService.CalculatePercent();

            var date = await dateService.GetBankDayAsync();
            var depositContractsToClose = await context.DepositContracts
                .Where(dc => !dc.IsClosed && dc.CloseDate.Date <= date)
                .ToListAsync();

            foreach (var dc in depositContractsToClose)
            {
                await depositContractService.CloseDepositContract(dc.Id);
            }
        }
    }
}
