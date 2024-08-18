namespace Shredule.Models
{
    public class Practice
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Location { get; set; }
    }
}
