using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GigaBankLab.Data;
using GigaBankLab.Models;

namespace GigaBankLab.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly GigaBankLabContext _context;

        public EditModel(GigaBankLabContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client =  await _context.Clients
                .Include(c => c.CityOfResidence)
                .Include(c => c.Citizenship)
                .Include(c => c.MaritalStatus)
                .Include(c => c.Disability)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            Client = client;

            ViewData["CitizenshipId"] = new SelectList(_context.Set<Citizenship>(), "Id", "Name");
            ViewData["CityOfResidenceId"] = new SelectList(_context.Set<City>(), "Id", "Name");
            ViewData["DisabilityId"] = new SelectList(_context.Set<Disability>(), "Id", "Name");
            ViewData["MaritalStatusId"] = new SelectList(_context.Set<MaritalStatus>(), "Id", "Name");
            
            return Page();
        }

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

            if (await _context.Clients.CountAsync(c => c.PassportSeries == Client.PassportSeries && c.PassportNumber == Client.PassportNumber) > 1)
            {
                ModelState.AddModelError("", "Клиент с данным номером паспорта уже существует");

                ViewData["CitizenshipId"] = new SelectList(_context.Set<Citizenship>(), "Id", "Name");
                ViewData["CityOfResidenceId"] = new SelectList(_context.Set<City>(), "Id", "Name");
                ViewData["DisabilityId"] = new SelectList(_context.Set<Disability>(), "Id", "Name");
                ViewData["MaritalStatusId"] = new SelectList(_context.Set<MaritalStatus>(), "Id", "Name");
                return Page();
            }

            _context.Attach(Client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(Client.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
