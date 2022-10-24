using KeepTrack.Models;

namespace KeepTrack.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Athletes.Any())
            {
                return;
            }

            var athletes = new Athlete[]
            {
                new Athlete{Name="Lorraine", Surname="Moyo", Weight=65, Height=170, StartDate=DateTime.Parse("2022-09-01")},
                new Athlete{Name="Sisanda", Surname="Zulu", Weight=55, Height=161, StartDate=DateTime.Parse("2022-10-01")},
                new Athlete{Name="Enzo", Surname="Dixon", Weight=45, Height=150, StartDate=DateTime.Parse("2022-12-01")},
                new Athlete{Name="Melanie", Surname="Psalms", Weight=35, Height=160, StartDate=DateTime.Parse("2020-01-01")},
                new Athlete{Name="Melanie", Surname="Psalms", Weight=35, Height=160, StartDate=DateTime.Parse("2020-01-31")}
            };
            context.Athletes.AddRange(athletes);
            context.SaveChanges();

            var personaltrainers = new PersonalTrainer[]
            {
                new PersonalTrainer{Name="Siya", Surname="Blue"},
                new PersonalTrainer{Name="Sdu", Surname="Pink"},
                new PersonalTrainer{Name="Senzo", Surname="Orange"}
            };
            context.PersonalTrainers.AddRange(personaltrainers);
            context.SaveChanges();

            var workouts = new Workout[]
            {
                new Workout{Title="5KM Jog", MetabollicEquivalent=6,  Duration=60, PersonalTrainerId=1},
                new Workout{Title="5km Cycking", MetabollicEquivalent=9,  Duration=60, PersonalTrainerId=1},
                new Workout{Title="Weight Lifting", MetabollicEquivalent=6,  Duration=45, PersonalTrainerId=2},
                new Workout{Title="Yoga", MetabollicEquivalent=6,  Duration=30, PersonalTrainerId=1},
                new Workout{Title="Functional Training", MetabollicEquivalent=7,  Duration=60, PersonalTrainerId=2},
                new Workout{Title="Swimming", MetabollicEquivalent=7,  Duration=45, PersonalTrainerId=3}
            };
            context.Workouts.AddRange(workouts);
            context.SaveChanges();

            var athleteworkouts = new AthleteWorkout[]
            {
                new AthleteWorkout{ AthleteId=1, WorkoutId=1},
                new AthleteWorkout{ AthleteId=1, WorkoutId=6},
                new AthleteWorkout{ AthleteId=2, WorkoutId=3},
                new AthleteWorkout{ AthleteId=2, WorkoutId=4},
                new AthleteWorkout{ AthleteId=2, WorkoutId=5},
                new AthleteWorkout{ AthleteId=3, WorkoutId=1},
                new AthleteWorkout{ AthleteId=4, WorkoutId=3},
                new AthleteWorkout{ AthleteId=5, WorkoutId=2},
                new AthleteWorkout{ AthleteId=4, WorkoutId=1},
                new AthleteWorkout{ AthleteId=5, WorkoutId=1},
            };
            context.AthleteWorkouts.AddRange(athleteworkouts);
            context.SaveChanges();
        }
    }
}
