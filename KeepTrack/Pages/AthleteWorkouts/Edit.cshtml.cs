using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KeepTrack.Data;
using KeepTrack.Models;

namespace KeepTrack.Pages.AthleteWorkouts
{
    public class EditModel : PageModel
    {
        private readonly KeepTrack.Data.ApplicationDbContext _context;

        public EditModel(KeepTrack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AthleteWorkout AthleteWorkout { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AthleteWorkouts == null)
            {
                return NotFound();
            }

            var athleteworkout =  await _context.AthleteWorkouts.FirstOrDefaultAsync(m => m.WorkoutId == id);
            if (athleteworkout == null)
            {
                return NotFound();
            }
            AthleteWorkout = athleteworkout;
           ViewData["AthleteId"] = new SelectList(_context.Athletes, "ID", "ID");
           ViewData["PersonalTrainerId"] = new SelectList(_context.PersonalTrainers, "Id", "Id");
           ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Id");
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

            _context.Attach(AthleteWorkout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AthleteWorkoutExists(AthleteWorkout.WorkoutId))
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

        private bool AthleteWorkoutExists(int id)
        {
          return _context.AthleteWorkouts.Any(e => e.WorkoutId == id);
        }
    }
}
