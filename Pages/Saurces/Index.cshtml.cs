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
    public class IndexModel : PageModel
    {
        private readonly ChilliTheBite.Data.ChilliTheBiteContext _context;

        public IndexModel(ChilliTheBite.Data.ChilliTheBiteContext context)
        {
            _context = context;
        }

        public IList<Saurce> Saurce { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Saurce != null)
            {
                Saurce = await _context.Saurce.ToListAsync();
            }
        }
    }
}
