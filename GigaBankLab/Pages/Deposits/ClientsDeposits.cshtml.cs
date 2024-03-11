using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;
using GigaBankLab.Services;

namespace GigaBankLab.Pages.Deposits
{
    public class ClientsDepositsModel : PageModel
    {
        private readonly GigaBankLabContext _context;
        private readonly DepositsService _depositsService;

        public ClientsDepositsModel(GigaBankLabContext context, DepositsService depositsService)
        {
            _context = context;
            _depositsService = depositsService;
        }

        public IList<DepositContract> DepositContracts { get; set; } = default!;

        public async Task OnGetAsync()
        {
            DepositContracts = await _context.DepositContracts
                .OrderByDescending(d => d.OpenDate)
                .Include(d => d.Client)
                .Include(d => d.CurrentAccount)
                .Include(d => d.Deposit)
                .Include(d => d.PercentAccount)
                .ToListAsync();
        }

        public async Task OnGetRevokeAsync(int depositContractId)
        {
            await _depositsService.RevokeDepositContract(depositContractId);

            DepositContracts = await _context.DepositContracts
                .OrderByDescending(d => d.OpenDate)
                .Include(d => d.Client)
                .Include(d => d.CurrentAccount)
                .Include(d => d.Deposit)
                .Include(d => d.PercentAccount)
                .ToListAsync();
        }
    }
}
