using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChilliTheBite.Data;
using ChilliTheBite.Models;

namespace ChilliTheBite.Pages.Saurces
{
    public class EditModel : PageModel
    {
        private readonly ChilliTheBite.Data.ChilliTheBiteContext _context;

        public EditModel(ChilliTheBite.Data.ChilliTheBiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Saurce Saurce { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Saurce == null)
            {
                return NotFound();
            }

            var saurce =  await _context.Saurce.FirstOrDefaultAsync(m => m.id == id);
            if (saurce == null)
            {
                return NotFound();
            }
            Saurce = saurce;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Saurce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaurceExists(Saurce.id))
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

        private bool SaurceExists(int id)
        {
          return (_context.Saurce?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
