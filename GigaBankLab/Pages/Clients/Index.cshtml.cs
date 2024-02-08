using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly GigaBankLab.Data.GigaBankLabContext _context;

        public IndexModel(GigaBankLab.Data.GigaBankLabContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await _context.Client
                .Include(c => c.Citizenship)
                .Include(c => c.CityOfResidence)
                .Include(c => c.Disability)
                .Include(c => c.MaritalStatus).ToListAsync();
        }
    }
}
