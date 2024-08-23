namespace Shredule.Models
{
    public class Show
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Venue { get; set; }
    }
}
