using Microsoft.EntityFrameworkCore;
using shredule.Models;
using Shredule.Models;

namespace Shredule.API
{
    public class AvailabilityAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/availability/{UserId}", (ShreduleDbContext db, int UserId) =>
            {
                var thisUsersAvailability = db.Ava
            });
        }
    }
}
