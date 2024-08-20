using Microsoft.EntityFrameworkCore;
using shredule.Models;
using Shredule.Models;

namespace Shredule.API
{
    public class ShowAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/shows", (ShreduleDbContext db, ShowDTO newShow) =>
            {
                try
                {
                    Show showToCreate = new Show();
                    showToCreate.DateTime = newShow.Date;
                    showToCreate.Venue = newShow.Venue;

                    db.Shows.Add(showToCreate);
                    db.SaveChanges();
                    return Results.Created($"/shows/{newShow.Id}", newShow);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Could not create show. Please check your data and try again.");
                }
            });

            app.MapPut("/shows/{bandName}", (ShreduleDbContext db, string bandName) => { 
            
            });
        }
    }
}
