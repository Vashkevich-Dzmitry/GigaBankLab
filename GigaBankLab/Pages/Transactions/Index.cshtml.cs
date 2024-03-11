using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Transactions
{
    public class IndexModel : PageModel
    {
        private readonly GigaBankLabContext _context;

        public IndexModel(GigaBankLabContext context)
        {
            _context = context;
        }

        public IList<Transaction> Transactions { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Transactions = await _context.Transactions
                .OrderByDescending(t => t.DateTime)
                .Include(t => t.FromAccount)
                .Include(t => t.ToAccount)
                .ToListAsync();
        }
    }
}
