using Microsoft.EntityFrameworkCore;
using Shredule.Models;

namespace Shredule.API
{
    public class ScheduleAPI
    {
        //get user's full schedule for all their bands
        public static void Map(WebApplication app)
        {
            app.MapGet("/user/schedule/{userId}", (ShreduleDbContext db, int UserId) =>
            {
                User user = db.Users.SingleOrDefault(u => u.Id == UserId);
                List<Band> userBands = user.Bands.ToList();
                List<Practice> allPractices = new List<Practice>();
                List<Show> allShows = new List<Show>();
                foreach (var band in userBands)
                {
                    foreach (var practice in band.Practices)
                    {
                        allPractices.Add(practice);
                    }
                    foreach (var show in band.Shows)
                    {
                        allShows.Add(show);
                    }
                }
                return (allPractices, allShows);
            });
        }
    }
}
