using Microsoft.EntityFrameworkCore;
using Shredule.Models;

namespace Shredule.API
{
    public class BandAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/user/bands/{userId}", (ShreduleDbContext db, int userId) =>
            {
                var usersBands = db.Bands.Include(b => b.Members).Where(bm => bm.Id == userId).ToList();
                if (usersBands.Any())
                {
                    return Results.Ok(usersBands);
                }
                else
                {
                    return Results.NotFound("");
                }

            });

            app.MapGet("/bands/band/{bandId}", (ShreduleDbContext db, int bandId) =>
            {
                var thisBand = db.Bands.FirstOrDefault(b => b.Id == bandId);
                if (thisBand != null)
                {
                    return Results.Ok(thisBand);
                }
                else
                {
                    return Results.NotFound("");
                }
            });

            app.MapDelete("/bands/{bandId}", (ShreduleDbContext db, int bandId) =>
            {
                var bandToDelete = db.Bands.FirstOrDefault(bm => bm.Id == bandId);
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

            app.MapPut("/bands/{bandId}", (ShreduleDbContext db, int bandId, NewBandDTO updatedBand) =>
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

            
        }
    }
}

