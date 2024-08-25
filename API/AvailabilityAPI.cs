using Microsoft.EntityFrameworkCore;
using Shredule.Migrations;
using Shredule.Models;

namespace Shredule.API
{
    public class AvailabilityAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/availability/{UserId}", (ShreduleDbContext db, int UserId) =>
            {
               var thisUsersAvailability = db.Availability.FirstOrDefault(a => a.UserId == UserId);
                if (thisUsersAvailability != null)
                {
                    return Results.Ok(thisUsersAvailability);
                }
                else
                {
                    return Results.NotFound("");
                }
            });

            app.MapPost("/availability", (ShreduleDbContext db, Availability newAvailability) =>
            {
                try
                {
                db.Availability.Add(newAvailability);
                db.SaveChanges();
                return Results.Created($"/availability/{newAvailability.Id}", newAvailability);
                }
                catch 
                {
                    return Results.BadRequest();
                }

            });
            app.MapPut("/availability/update/{userId}", (ShreduleDbContext db, int userId, Availability updatedAvailability) =>
            {
                
                    var availabilityToUpdate = db.Availability.FirstOrDefault(a => a.UserId == userId);
                    if (availabilityToUpdate != null) {
                        availabilityToUpdate.MonMorn = updatedAvailability.MonMorn;
                        availabilityToUpdate.TueMorn = updatedAvailability.TueMorn;
                        availabilityToUpdate.WedMorn = updatedAvailability.WedMorn;
                        availabilityToUpdate.ThurMorn = updatedAvailability.ThurMorn;
                        availabilityToUpdate.FriMorn = updatedAvailability.FriMorn;
                        availabilityToUpdate.SatMorn = updatedAvailability.SatMorn;
                        availabilityToUpdate.SunMorn = updatedAvailability.SunMorn;
                        availabilityToUpdate.MonNight = updatedAvailability.MonNight;
                        availabilityToUpdate.TueNight = updatedAvailability.TueNight;
                        availabilityToUpdate.WedNight = updatedAvailability.WedNight;
                        availabilityToUpdate.ThurNight = updatedAvailability.ThurNight;
                        availabilityToUpdate.FriNight = updatedAvailability.FriNight;
                        availabilityToUpdate.SatNight = updatedAvailability.SatNight;
                        availabilityToUpdate.SunNight = updatedAvailability.SunNight;
                    db.SaveChanges();
                    return Results.Created($"/availability/update/{updatedAvailability.Id}", availabilityToUpdate);
                    }
                    else
                    {
                    return Results.NotFound("This availability cannot be updated");
                    }
            });
        }
    }
}
