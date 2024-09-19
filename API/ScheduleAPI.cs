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
                List<Band> userBands = db.Bands
                                         .Include(band => band.Practices)
                                         .Include(band => band.Shows)
                                         .Where(band => band.Members.Contains(user)).ToList();
                if (userBands == null)
                {
                    return Results.NotFound("No bands found");
                }
                else
                {

                    ScheduleDTO userSchedule = new ScheduleDTO()
                    {
                        Practices = [],
                        Shows = []
                    };
                    foreach (var band in userBands)
                    {
                        if (band.Practices != null)
                        {
                            foreach (var practice in band.Practices)
                            {
                                userSchedule.Practices.Add(practice);
                            }
                        }
                        if (band.Shows != null)
                        {
                            foreach (var show in band.Shows)
                            {
                                userSchedule.Shows.Add(show);
                            }
                        }
                    }
                    if (userSchedule.Shows.Count > 0 || userSchedule.Practices.Count > 0)
                    {
                        return Results.Ok(userSchedule);
                    }
                    else
                    {
                        return Results.Ok("Nothing scheduled");
                    }
                }
            });
        }
    }
}
