using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Credits
{
    public class CreditProductsModel : PageModel
    {
        private readonly GigaBankLabContext _context;

        public CreditProductsModel(GigaBankLabContext context)
        {
            _context = context;
        }

        public IList<CreditProduct> CreditProducts { get; set; } = default!;

        public async Task OnGetAsync()
        {
            CreditProducts = await _context.CreditProducts
                .Include(c => c.Currency)
                .ToListAsync();
        }
    }
}
