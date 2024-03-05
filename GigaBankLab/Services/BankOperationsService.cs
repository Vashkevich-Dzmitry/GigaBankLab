﻿using GigaBankLab.Data;
using GigaBankLab.Models;
using Microsoft.EntityFrameworkCore;

namespace GigaBankLab.Services
{
        public class BankOperationsService
        {
            private readonly GigaBankLabContext context;
            private readonly DepositContractsService depositContractService;
            private readonly CurrentDateService dateService;

            public BankOperationsService(GigaBankLabContext context, DepositContractsService depositContractService, CurrentDateService dateService)
            {
                this.context = context;
                this.depositContractService = depositContractService;
                this.dateService = dateService;
            }

            public async Task CloseDayAsync()
            {
                await depositContractService.CalculatePercent();

                var date = await dateService.GetTodayAsync();
                date = date.AddDays(1);
                var depositContractsToClose = await context.DepositContracts
                    .Where(dc => !dc.IsClosed && dc.CloseDate.Date <= date)
                    .ToListAsync();

                foreach (var dc in depositContractsToClose)
                {
                    await depositContractService.CloseDepositContract(dc.Id);
                }

                await dateService.SetToday(date);
            }
        }
    }