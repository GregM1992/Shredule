using Microsoft.EntityFrameworkCore;
using Shredule.Models;

namespace Shredule.API
{
    public class PracticeAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/bandPractice/{bandId}", (ShreduleDbContext db, int bandId) =>
            {
                var bandPractices = db.Practices.Where(p => p.BandId == bandId).ToList();
                if (bandPractices.Count > 0)
                {
                    return Results.Ok(bandPractices);
                }
                else
                {
                    return Results.NotFound("");
                }

            });

            app.MapPost("/bandPractice/{bandId}", (ShreduleDbContext db, int bandId, DateTime newDate, Practice newPractice) =>
            {
                try
                {
                    newPractice.BandId = bandId;
                    newPractice.DateTime = newDate;
                    db.Practices.Add(newPractice);
                    db.SaveChanges();
                    return Results.Created($"/bandPractices/{newPractice.Id}", newPractice);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to create practice");
                }

            });

            app.MapDelete("/bandPractice/{practiceId}", (ShreduleDbContext db, int practiceId) =>
            {
                var practiceToDelete = db.Practices.FirstOrDefault(p => p.Id == practiceId);
                if (practiceToDelete != null)
                {
                    db.Practices.Remove(practiceToDelete);
                    db.SaveChanges();
                    return Results.Ok("Practice has been successfully removed");
                }
                else
                {
                    return Results.NotFound("This practice does not exist or has already been deleted");
                }


            });
        }
    }
}
