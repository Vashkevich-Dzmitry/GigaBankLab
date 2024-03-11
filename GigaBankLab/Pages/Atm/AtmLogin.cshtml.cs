using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GigaBankLab.Data;
using GigaBankLab.Models.Atm;
using GigaBankLab.Services;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Atm
{
    public class AtmLoginModel : PageModel
    {
        private readonly GigaBankLabContext _context;
        private readonly AtmService _atmService;

        public AtmLoginModel(GigaBankLabContext context, AtmService atmService)
        {
            _context = context;
            _atmService = atmService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AtmLoginDTO AtmLoginDTO { get; set; } = default!;
        
        private static string _lastCreditCardNumber { get; set; } = string.Empty;
        private static int _trialsNumber { get; set; } = 0;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_lastCreditCardNumber != AtmLoginDTO.CreditCardNumber)
            {
                _lastCreditCardNumber = AtmLoginDTO.CreditCardNumber;
                _trialsNumber = 0;
            }

            var creditContractId = await _atmService.GetCreditContractIdByCredentials(AtmLoginDTO);

            if (creditContractId > 0)
            {
                _trialsNumber = 0;

                return RedirectToPage("./AtmOperations", new { CreditContractId = creditContractId });
            }
            else
            {
                _trialsNumber++;

                if (_trialsNumber == 3) 
                {
                    _trialsNumber = 0;
                    return RedirectToPage("../Index");
                }
                else
                {
                    return Page();
                }
            }

        }
    }
}
