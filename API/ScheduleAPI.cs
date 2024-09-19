using Microsoft.EntityFrameworkCore;
using Shredule.Models;

namespace Shredule.API
{
    public class ScheduleAPI
    {
        //get user's full schedule for all their bands
        public static void Map(WebApplication app)
        {
            app.MapGet("/user/{userId}/schedule", (ShreduleDbContext db, int UserId) =>
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

            //get single band's full schedule
            app.MapGet("/band/{bandId}/schedule", (ShreduleDbContext db, int bandId) => { 
                Band band = db.Bands
                .Include((band) => band.Practices)
                .Include((band) => band.Shows)
                .SingleOrDefault((band) => band.Id == bandId);
                if (band == null)
                {
                    return Results.NotFound("Band not found");
                } else
                {
                    ScheduleDTO bandSchedule = new ScheduleDTO();
                    bandSchedule.Practices = [];
                    if (band.Practices.Count > 0)
                    {
                        foreach (Practice practice in band.Practices)
                        {
                            bandSchedule.Practices.Add(practice);
                        }
                    }
                    bandSchedule.Shows = [];
                    if (band.Shows.Count > 0)
                    {
                        foreach (Show show in band.Shows)
                        {
                            bandSchedule.Shows.Add(show);
                        }
                    }
                    if (bandSchedule.Shows.Count > 0 || bandSchedule.Practices.Count > 0)
                    {
                        return Results.Ok(bandSchedule);
                    } else
                    {
                        return Results.Ok("Nothing scheduled");
                    }


                }
            });
        }
    }
}
