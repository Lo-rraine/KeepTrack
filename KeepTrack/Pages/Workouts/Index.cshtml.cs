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
    public class IndexModel : PageModel
    {
        private readonly KeepTrack.Data.ApplicationDbContext _context;

        public IndexModel(KeepTrack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Workout> Workout { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Workouts != null)
            {
                Workout = await _context.Workouts
                .Include(w => w.PersonalTrainer).ToListAsync();
            }
        }
    }
}
