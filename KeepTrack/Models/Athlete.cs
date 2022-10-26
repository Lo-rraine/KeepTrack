using System.ComponentModel.DataAnnotations;

namespace KeepTrack.Models

{
    public enum Gender
    {
        Male, Female, NonBinary
    }
    public class Athlete
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [DisplayFormat(NullDisplayText = "-")]
        public Gender? Gender { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<AthleteWorkout> AthleteWorkouts { get; set; }
    }
}
