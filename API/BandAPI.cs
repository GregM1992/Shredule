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
            app.MapPost("/bands", (ShreduleDbContext db, NewBandDTO bandToCreate, int userId) =>
            {
                try
                {
                    User bandCreator = db.Users.Include(u => u.Bands).FirstOrDefault(u => u.Id == userId);
                    Band newBand = new Band
                    {
                        Id = bandToCreate.Id,
                        Name = bandToCreate.Name,
                        Password = bandToCreate.Password,
                        LeaderId = userId,
                        Members = [bandCreator]
                    };

                    db.Bands.Add(newBand);
                    db.SaveChanges();

                    Band bandCreated = db.Bands.Include(b => b.Members).FirstOrDefault(b => b.Id == bandToCreate.Id);
       
                    if (bandCreated != null)
                    {
                        bandCreated.Members.Add(bandCreator);
                        bandCreator.Bands.Add(bandCreated);
                        db.SaveChanges();
                    }

                    return Results.Created($"/bands/{newBand.Id}", newBand);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to create band, check your data and try again");
                }
            });

            app.MapPost("/bands/{bandId}/join", (ShreduleDbContext db, int bandId, int userId) =>
            {
                var bandToJoin = db.Bands.Include(b => b.Members).FirstOrDefault(b => b.Id == bandId);
                var userToJoin = db.Users.FirstOrDefault(u => u.Id == userId);
                if (bandToJoin != null && userToJoin != null)
                {
                    if (bandToJoin.Members == null)
                    {
                        bandToJoin.Members = new List<User>();
                    }
                    bandToJoin.Members.Add(userToJoin);
                    db.SaveChanges();
                    return Results.Created($"/bands/{bandId}", bandToJoin);
                }
                else
                {
                    return Results.NotFound("Band or user not found");
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

