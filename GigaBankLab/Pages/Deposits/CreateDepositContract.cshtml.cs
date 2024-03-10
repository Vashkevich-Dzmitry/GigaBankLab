using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GigaBankLab.Data;
using GigaBankLab.Services;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Deposits
{
    public class CreateDepositContractModel : PageModel
    {
        private readonly GigaBankLabContext _context;
        private readonly DepositsService _depositsService;

        public CreateDepositContractModel(GigaBankLabContext context, DepositsService depositsService)
        {
            _context = context;
            _depositsService = depositsService;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FirstName");
            ViewData["DepositId"] = new SelectList(_context.Deposits, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public DepositDTO DepositDTO { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FirstName");
                ViewData["DepositId"] = new SelectList(_context.Deposits, "Id", "Name");
                return Page();
            }

            await _depositsService.CreateDepositContract(DepositDTO);

            return RedirectToPage("./ClientsDeposits");
        }
    }
}
