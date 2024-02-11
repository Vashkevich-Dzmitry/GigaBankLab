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
    public class DetailsModel : PageModel
    {
        private readonly GigaBankLab.Data.GigaBankLabContext _context;

        public DetailsModel(GigaBankLab.Data.GigaBankLabContext context)
        {
            _context = context;
        }

        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.CityOfResidence)
                .Include(c => c.Citizenship)
                .Include(c => c.MaritalStatus)
                .Include(c => c.Disability)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (client == null)
            {
                return NotFound();
            }
            else
            {
                Client = client;
            }
            return Page();
        }
    }
}
