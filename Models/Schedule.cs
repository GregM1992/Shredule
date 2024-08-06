using Shredule.Models;

namespace shredule.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public ICollection<Show>? Shows { get; set; }
        public ICollection<Practice>? Practices { get; set; }
    }
}
