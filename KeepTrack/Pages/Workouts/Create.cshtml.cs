using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KeepTrack.Data;
using KeepTrack.Models;

namespace KeepTrack.Pages.Workouts
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
        ViewData["PersonalTrainerId"] = new SelectList(_context.PersonalTrainers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Workout Workout { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workouts.Add(Workout);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
