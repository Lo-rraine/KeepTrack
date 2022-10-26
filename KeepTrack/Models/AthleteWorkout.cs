namespace KeepTrack.Models
{
    public class AthleteWorkout
    {
        public int ID { get; set; }
        public int AthleteId { get; set; }
        public Athlete Athlete { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int PersonalTrainerId { get; set; }
        public PersonalTrainer PersonalTrainer { get; set; }
    }
}
