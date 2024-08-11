using Microsoft.EntityFrameworkCore;

namespace Shredule.API
{
    public class BandAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/bands/{id}", (ShreduleDbContext db, int id) =>
            {
                var usersBands = db.Bands.Include(b => b.Members).Where(bm => bm.Id == id).ToList();
                if (usersBands.Any())
                {
                    return Results.Ok(usersBands);
                }
                else
                {
                    return Results.NotFound("");
                }

            });
        }
    }
}
