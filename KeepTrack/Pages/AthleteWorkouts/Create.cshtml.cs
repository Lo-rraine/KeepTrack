using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KeepTrack.Data;
using KeepTrack.Models;

namespace KeepTrack.Pages.AthleteWorkouts
{
    public class CreateModel : PageModel
    {
        private readonly KeepTrack.Data.ApplicationDbContext _context;

        public CreateModel(KeepTrack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AthleteId"] = new SelectList(_context.Athletes, "ID", "ID");
        ViewData["PersonalTrainerId"] = new SelectList(_context.PersonalTrainers, "Id", "Id");
        ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public AthleteWorkout AthleteWorkout { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AthleteWorkouts.Add(AthleteWorkout);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
