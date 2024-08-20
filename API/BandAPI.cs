using Microsoft.EntityFrameworkCore;
using shredule.Models;
using Shredule.Models;

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

            app.MapGet("/bands/band/{id}", (ShreduleDbContext db, int id) =>
            {
                var thisBand = db.Bands.FirstOrDefault(b => b.Id == id);
                if (thisBand != null)
                {
                    return Results.Ok(thisBand);
                }
                else
                {
                    return Results.NotFound("");
                }
            });

            app.MapDelete("/bands/{id}", (ShreduleDbContext db, int id) =>
            {
                var bandToDelete = db.Bands.FirstOrDefault(bm => bm.Id == id);
                if (bandToDelete != null)
                {
                    db.Bands.Remove(bandToDelete);
                    db.SaveChanges();
                    return Results.Ok("This band has been deleted");
                }
                else
                {
                    return Results.NotFound("");
                }
            });

            app.MapPost("/bands", (ShreduleDbContext db, NewBandDTO bandToCreate) =>
            {
                try
                {
                    Band newBand = new()
                    {
                        Id = bandToCreate.Id,
                        Name = bandToCreate.Name,
                        Password = bandToCreate.Password,
                    };
                    db.Bands.Add(newBand);
                    db.SaveChanges();
                    return Results.Created($"/bands/{newBand.Id}", newBand);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to create band, check your data and try again");
                }
            });

            app.MapPut("/bands/{id}", (ShreduleDbContext db, int id, NewBandDTO updatedBand) =>
            {
                var bandToUpdate = db.Bands.FirstOrDefault();
                if (bandToUpdate != null)
                {
                    bandToUpdate.Name = updatedBand.Name;
                    bandToUpdate.Password = updatedBand.Password;
                    db.SaveChanges();
                    return Results.Created($"/bands/{updatedBand.Id}", updatedBand);
                }
                else
                {
                    return Results.BadRequest();
                }
            });

            app.MapGet("/band/shows/{bandId}", (ShreduleDbContext db, int bandId) =>
            {
                var bandsShows = db.Bands.Include(b => b.Shows).Where(b => b.Id == bandId);
                if (bandsShows.Any())
                {
                return Results.Ok(bandsShows);
                }
                else
                {
                    return Results.NotFound("");
                }
            });
        }
    }
}

