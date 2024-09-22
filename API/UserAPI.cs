using Microsoft.EntityFrameworkCore;
using Shredule.Models;

namespace Shredule.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/users/{id}", (ShreduleDbContext db, int id) => // get user by id
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return Results.NotFound("");
                }

                return Results.Ok(user);
            });

            app.MapGet("/checkuser/{id}", (ShreduleDbContext db, int id) => // check for user
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return Results.NotFound("");
                }

                return Results.Ok(user);
            });

            app.MapPost("/users/register", (ShreduleDbContext db, User newUser) => //register user
            {
                try
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return Results.Created($"/users/{newUser.Id}", newUser);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("");
                }
            });

            app.MapPut("/users/{id}", (ShreduleDbContext db, int id, User user) => // update user
            {
                var userBeingUpdated = db.Users.FirstOrDefault(u => u.Id == id);

                if (userBeingUpdated == null)
                {
                    return Results.NotFound("No user found");
                }

                userBeingUpdated.Id = user.Id;
                userBeingUpdated.UserName = user.UserName;
                userBeingUpdated.Name = user.Name;
                userBeingUpdated.Password = user.Password;
                userBeingUpdated.ImageUrl = user.ImageUrl;
                db.SaveChanges();
                return Results.Ok("User has been updated");
            });



        }
    }
}
