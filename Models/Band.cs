namespace Shredule.Models
{
    public class Band
    {
        public int Id { get; set; }
        public int LeaderId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public int ScheduleId { get; set; }
        public ICollection<Show>? Shows { get; set; }
        public ICollection<Practice>? Practices { get; set; }
        public ICollection<User>? Members { get; set; }

    }
}
