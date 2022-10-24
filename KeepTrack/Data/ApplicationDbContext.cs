using KeepTrack.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeepTrack.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<AthleteWorkout> AthleteWorkouts { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainers { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AthleteWorkout>()
                .HasKey(aw => new { aw.WorkoutId, aw.AthleteId });

            modelBuilder.Entity<AthleteWorkout>()
                .HasOne(aw => aw.Athlete)
                .WithMany(a => a.AthleteWorkouts)
                .HasForeignKey(aw => aw.AthleteId);

            modelBuilder.Entity<AthleteWorkout>()
                .HasOne(aw => aw.Workout)
                .WithMany(a => a.AthleteWorkouts)
                .HasForeignKey(aw => aw.WorkoutId);
        }
    }
}