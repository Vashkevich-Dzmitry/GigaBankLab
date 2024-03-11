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

namespace GigaBankLab.Pages.Credits
{
    public class ClientsCreditsModel : PageModel
    {
        private readonly GigaBankLabContext _context;
        private readonly CreditsService _creditsSevice;

        public ClientsCreditsModel(GigaBankLabContext context, CreditsService creditsService)
        {
            _context = context;
            _creditsSevice = creditsService;
        }

        public IList<CreditContract> CreditContracts { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CreditContracts = await _context.CreditContracts
                .Include(c => c.Client)
                .Include(c => c.Credit)
                .Include(c => c.CurrentAccount)
                .Include(c => c.PercentAccount)
                .ToListAsync();

            foreach (var contract in CreditContracts)
            {
                contract.Plan = _creditsSevice.CalculateCreditRepaymentPlan(contract.Sum, (decimal)contract.Credit!.Percent, contract.Credit!.Duration, contract.Credit!.Annuity, contract.OpenDate);
            }
        }
    }
}
