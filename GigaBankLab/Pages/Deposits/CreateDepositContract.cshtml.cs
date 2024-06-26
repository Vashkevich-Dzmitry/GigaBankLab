﻿using Microsoft.AspNetCore.Mvc;
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "IdentificationNumber");
            ViewData["DepositId"] = new SelectList(_context.DepositProducts, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public DepositContractDTO DepositContractDTO { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "IdentificationNumber");
                ViewData["DepositId"] = new SelectList(_context.DepositProducts, "Id", "Description");
                return Page();
            }

            await _depositsService.CreateDepositContract(DepositContractDTO);

            return RedirectToPage("./DepositContracts");
        }
    }
}
