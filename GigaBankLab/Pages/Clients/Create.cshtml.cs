using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly GigaBankLab.Data.GigaBankLabContext _context;

        public CreateModel(GigaBankLab.Data.GigaBankLabContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CitizenshipId"] = new SelectList(_context.Set<Citizenship>(), "Id", "Id");
        ViewData["CityOfResidenceId"] = new SelectList(_context.Set<City>(), "Id", "Id");
        ViewData["DisabilityId"] = new SelectList(_context.Set<Disability>(), "Id", "Id");
        ViewData["MaritalStatusId"] = new SelectList(_context.Set<MaritalStatus>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Client.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
