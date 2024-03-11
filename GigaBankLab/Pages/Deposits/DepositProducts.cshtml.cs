using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Deposits
{
    public class IndexModel : PageModel
    {
        private readonly GigaBankLabContext _context;

        public IndexModel(GigaBankLabContext context)
        {
            _context = context;
        }

        public IList<DepositProduct> DepositProducts { get;set; } = default!;

        public async Task OnGetAsync()
        {
            DepositProducts = await _context.DepositProducts
                .Include(d => d.Currency).ToListAsync();
        }
    }
}
