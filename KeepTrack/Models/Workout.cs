namespace KeepTrack.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MetabollicEquivalent { get; set; }
        public int Duration { get; set; }
        public ICollection<AthleteWorkout> AthleteWorkouts { get; set; }

    }
}
