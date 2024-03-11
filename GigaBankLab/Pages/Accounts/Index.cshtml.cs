using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly GigaBankLabContext _context;

        public IndexModel(GigaBankLabContext context)
        {
            _context = context;
        }

        public IList<Account> Accounts { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Accounts = await _context.Accounts
                .Include(a => a.Client)
                .Include(a => a.Currency)
                .ToListAsync();
        }
    }
}
