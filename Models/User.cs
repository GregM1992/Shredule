namespace Shredule.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int AvailabilityId { get; set; }
        public ICollection<Band>? Bands { get; set; }
    }
}
