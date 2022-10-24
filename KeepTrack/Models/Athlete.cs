namespace KeepTrack.Models
{
    public class Athlete
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<AthleteWorkout> AthleteWorkouts { get; set; }
    }
}
