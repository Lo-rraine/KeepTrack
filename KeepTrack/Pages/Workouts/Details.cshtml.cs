using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KeepTrack.Data;
using KeepTrack.Models;

namespace KeepTrack.Pages.Workouts
{
    public class DetailsModel : PageModel
    {
        private readonly KeepTrack.Data.ApplicationDbContext _context;

        public DetailsModel(KeepTrack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Workout Workout { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Workouts == null)
            {
                return NotFound();
            }

            var workout = await _context.Workouts.FirstOrDefaultAsync(m => m.Id == id);
            if (workout == null)
            {
                return NotFound();
            }
            else 
            {
                Workout = workout;
            }
            return Page();
        }
    }
}
