namespace shredule.Models
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Venue { get; set; }
        public ICollection<Band>? Bands { get; set; }
    }
}
