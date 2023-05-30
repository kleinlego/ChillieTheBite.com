using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChilliTheBite.Data;
using ChilliTheBite.Models;

namespace ChilliTheBite.Pages.Saurces
{
    public class DeleteModel : PageModel
    {
        private readonly ChilliTheBite.Data.ChilliTheBiteContext _context;

        public DeleteModel(ChilliTheBite.Data.ChilliTheBiteContext context)
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

            var saurce = await _context.Saurce.FirstOrDefaultAsync(m => m.id == id);

            if (saurce == null)
            {
                return NotFound();
            }
            else 
            {
                Saurce = saurce;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Saurce == null)
            {
                return NotFound();
            }
            var saurce = await _context.Saurce.FindAsync(id);

            if (saurce != null)
            {
                Saurce = saurce;
                _context.Saurce.Remove(Saurce);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
