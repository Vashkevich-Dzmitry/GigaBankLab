using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GigaBankLab.Data;
using GigaBankLab.Models;
using Microsoft.EntityFrameworkCore;

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
            ViewData["CitizenshipId"] = new SelectList(_context.Set<Citizenship>(), "Id", "Name");
            ViewData["CityOfResidenceId"] = new SelectList(_context.Set<City>(), "Id", "Name");
            ViewData["DisabilityId"] = new SelectList(_context.Set<Disability>(), "Id", "Name");
            ViewData["MaritalStatusId"] = new SelectList(_context.Set<MaritalStatus>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CitizenshipId"] = new SelectList(_context.Set<Citizenship>(), "Id", "Name");
                ViewData["CityOfResidenceId"] = new SelectList(_context.Set<City>(), "Id", "Name");
                ViewData["DisabilityId"] = new SelectList(_context.Set<Disability>(), "Id", "Name");
                ViewData["MaritalStatusId"] = new SelectList(_context.Set<MaritalStatus>(), "Id", "Name");
                return Page();
            }

            if (await _context.Clients.AnyAsync(c => c.PassportSeries == Client.PassportSeries && c.PassportNumber == Client.PassportNumber))
            {
                ModelState.AddModelError("", "Клиент с данным номером паспорта уже существует");
                ViewData["CitizenshipId"] = new SelectList(_context.Set<Citizenship>(), "Id", "Name");
                ViewData["CityOfResidenceId"] = new SelectList(_context.Set<City>(), "Id", "Name");
                ViewData["DisabilityId"] = new SelectList(_context.Set<Disability>(), "Id", "Name");
                ViewData["MaritalStatusId"] = new SelectList(_context.Set<MaritalStatus>(), "Id", "Name");
                return Page();
            }

            _context.Clients.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
