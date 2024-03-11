using GigaBankLab.Data;
using GigaBankLab.Models;
using GigaBankLab.Models.Atm;
using GigaBankLab.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GigaBankLab.Pages.Atm
{
    public class AtmOperationsModel : PageModel
    {
        private readonly GigaBankLabContext _context;
        private readonly AtmService _atmService;
        private readonly CreditsService _creditService;

        public AtmOperationsModel(GigaBankLabContext context, AtmService atmService, CreditsService creditService)
        {
            _context = context;
            _atmService = atmService;
            _creditService = creditService;
        }

        [BindProperty]
        public AtmCashWithdrawalDTO AtmCashWithdrawalDTO { get; set; }
        public CreditContract CreditContract { get; set; }
        public int CreditContractId { get; set; }
        public double Sum { get; set; }

        public async Task OnGetAsync(int creditContractId)
        {
            CreditContractId = creditContractId;
            CreditContract = (await _context.CreditContracts
                .Where(cc => cc.Id == CreditContractId)
                .Include(cc => cc.CreditProduct)
                .Include(cc => cc.Client)
                .Include(cc => cc.CurrentAccount)
                .Include(cc => cc.PercentAccount)
                .Include(cc => cc.CreditProduct!.Currency)
                .ToListAsync()).First();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CreditContractId = AtmCashWithdrawalDTO.CreditContractId;
            CreditContract = (await _context.CreditContracts
                .Where(cc => cc.Id == CreditContractId)
                .Include(cc => cc.CurrentAccount)
                .ToListAsync()).First();

            var account = CreditContract.CurrentAccount;
            var balance = account!.Balance;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (AtmCashWithdrawalDTO.Sum > balance)
            {
                ModelState.AddModelError("", "Недостаточно средств");
                return Page();
            }
            else
            {
                await _atmService.WithdrawCash(AtmCashWithdrawalDTO);
                return RedirectToPage("./AtmOperations", new { CreditContractId = AtmCashWithdrawalDTO.CreditContractId });
            }
        }
    }
}
