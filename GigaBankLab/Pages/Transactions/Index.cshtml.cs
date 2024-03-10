using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Transactions
{
    public class IndexModel : PageModel
    {
        private readonly GigaBankLab.Data.GigaBankLabContext _context;

        public IndexModel(GigaBankLab.Data.GigaBankLabContext context)
        {
            _context = context;
        }

        public IList<Transaction> Transaction { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Transaction = await _context.Transactions
                .OrderByDescending(t => t.DateTime)
                .Include(t => t.FromAccount)
                .Include(t => t.ToAccount)
                .ToListAsync();
        }
    }
}
