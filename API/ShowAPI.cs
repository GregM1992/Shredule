using Microsoft.EntityFrameworkCore;
using shredule.Models;
using Shredule.Models;

namespace Shredule.API
{
    public class ShowAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/shows/{bandId}", (ShreduleDbContext db, int bandId) =>
            {
               var bandsShows = db.Shows.Where(bs => bs.BandId == bandId).ToList();
                if (bandsShows.Count > 0)
                {
                    return Results.Ok(bandsShows);

                }
                else
                {
                    return Results.NotFound("");
                }
            });

            app.MapPost("/shows", (ShreduleDbContext db, Show newShow) =>
            {
                try
                {
                    Show showToCreate = new();
                    showToCreate.BandId = newShow.BandId;
                    showToCreate.Venue = newShow.Venue;
                    showToCreate.DateTime = newShow.DateTime;
                    db.Shows.Add(showToCreate);
                    db.SaveChanges();
                    return Results.Created($"/shows/{showToCreate.Id}", showToCreate);
                }
                catch
                {
                    return Results.BadRequest();
                }
            });

            app.MapDelete("/shows/{showId}", (ShreduleDbContext db, int showId) =>
            {
                var showToDelete = db.Shows.FirstOrDefault(s => s.Id == showId);
                if (showToDelete != null)
                {
                    db.Shows.Remove(showToDelete);
                    db.SaveChanges();
                    return Results.Ok("Show to delete");
                }
                else
                {
                    return Results.NotFound("");
                }
            });

            app.MapPut("/shows/{showId}", (ShreduleDbContext db, int showId, Show updatedShow) =>
            {
                var showToUpdate = db.Shows.FirstOrDefault(s => s.Id == showId);
                if (showToUpdate != null)
                {
                    showToUpdate.Venue = updatedShow.Venue;
                    showToUpdate.DateTime = updatedShow.DateTime;
                    db.SaveChanges();
                    return Results.Created($"/shows/{showToUpdate.Id}", updatedShow);
                }
                else
                {
                    return Results.BadRequest("This show does not exist");
                }
            });
            

           
        }
    }
}
