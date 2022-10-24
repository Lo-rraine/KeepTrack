using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KeepTrack.Data;
using KeepTrack.Models;

namespace KeepTrack.Pages.Athletes
{
    public class DeleteModel : PageModel
    {
        private readonly KeepTrack.Data.ApplicationDbContext _context;

        public DeleteModel(KeepTrack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Athlete Athlete { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Athletes == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes.FirstOrDefaultAsync(m => m.ID == id);

            if (athlete == null)
            {
                return NotFound();
            }
            else 
            {
                Athlete = athlete;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Athletes == null)
            {
                return NotFound();
            }
            var athlete = await _context.Athletes.FindAsync(id);

            if (athlete != null)
            {
                Athlete = athlete;
                _context.Athletes.Remove(Athlete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
