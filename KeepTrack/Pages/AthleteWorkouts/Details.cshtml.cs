﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KeepTrack.Data;
using KeepTrack.Models;

namespace KeepTrack.Pages.AthleteWorkouts
{
    public class DetailsModel : PageModel
    {
        private readonly KeepTrack.Data.ApplicationDbContext _context;

        public DetailsModel(KeepTrack.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AthleteWorkout AthleteWorkout { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AthleteWorkouts == null)
            {
                return NotFound();
            }

            var athleteworkout = await _context.AthleteWorkouts.FirstOrDefaultAsync(m => m.WorkoutId == id);
            if (athleteworkout == null)
            {
                return NotFound();
            }
            else 
            {
                AthleteWorkout = athleteworkout;
            }
            return Page();
        }
    }
}
