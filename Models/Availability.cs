namespace shredule.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool MonMorn { get; set; }
        public bool TueMorn { get; set; }
        public bool WedMorn { get; set; }
        public bool ThurMorn { get; set; }
        public bool FriMorn { get; set; }
        public bool SatMorn { get; set; }
        public bool SunMorn { get; set; }
        public bool MonNight { get; set; }
        public bool TueNight { get; set; }
        public bool WedNight { get; set; }
        public bool ThurNight { get; set; }
        public bool FriNight { get; set; }
        public bool SatNight { get; set; }
        public bool SunNight { get; set; }
    }
}
