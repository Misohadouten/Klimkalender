namespace KlimEvenementenAPI.Models
{
    public class ClimbingEvent
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public DateTime date { get; set; }
        public TimeSpan Time { get; set; }

    }
}
