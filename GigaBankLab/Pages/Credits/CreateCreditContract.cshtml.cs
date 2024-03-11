using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GigaBankLab.Data;
using GigaBankLab.Models;
using GigaBankLab.Services;

namespace GigaBankLab.Pages.Credits
{
    public class CreateCreditContractModel : PageModel
    {
        private readonly GigaBankLabContext _context;
        private readonly CreditsService _creditsSevice;

        public CreateCreditContractModel(GigaBankLabContext context, CreditsService creditsService)
        {
            _context = context;
            _creditsSevice = creditsService;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "IdentificationNumber");
            ViewData["CreditId"] = new SelectList(_context.CreditProducts, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public CreditContractDTO CreditContractDTO { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "IdentificationNumber");
                ViewData["CreditId"] = new SelectList(_context.CreditProducts, "Id", "Description");
                return Page();
            }

            await _creditsSevice.CreateCreditContract(CreditContractDTO);

            return RedirectToPage("./CreditContracts");
        }
    }
}
