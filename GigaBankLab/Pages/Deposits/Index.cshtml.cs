using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IList<Deposit> Deposit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Deposit = await _context.Deposits
                .Include(d => d.Currency).ToListAsync();
        }
    }
}
