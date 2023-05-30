using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChilliTheBite.Data;
using ChilliTheBite.Models;

namespace ChilliTheBite.Pages.Saurces
{
    public class CreateModel : PageModel
    {
        private readonly ChilliTheBite.Data.ChilliTheBiteContext _context;

        public CreateModel(ChilliTheBite.Data.ChilliTheBiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Saurce Saurce { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Saurce == null || Saurce == null)
            {
                return Page();
            }

            _context.Saurce.Add(Saurce);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index"); //rediects to the next page
        }
    }
}
