using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly GigaBankLabContext _context;

        public IndexModel(GigaBankLabContext context)
        {
            _context = context;
        }

        public IList<Client> Clients { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Clients = await _context.Clients
                .Include(c => c.Citizenship)
                .Include(c => c.CityOfResidence)
                .Include(c => c.Disability)
                .Include(c => c.MaritalStatus).ToListAsync();
        }
    }
}
