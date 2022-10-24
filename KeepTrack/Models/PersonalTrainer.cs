namespace KeepTrack.Models
{
    public class PersonalTrainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Workout> Workouts { get; set; }

    }
}
