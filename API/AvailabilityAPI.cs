using Microsoft.EntityFrameworkCore;
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
        }
    }
}
