using API_Blazor.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace API_Blazor.Data
{
    public class DatabaseConTextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async System.Threading.Tasks.Task SeedAsync(DatabaseContext context, ILogger<DatabaseConTextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = (new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "Thuyen",
                    Email = "admin@gmail.com",
                    PhoneNumber = "5121201121",
                    UserName = "thuyenla",


                });
                user.PasswordHash = _passwordHasher.HashPassword(user, "thuyen123");
                context.Users.Add(user);
                context.SaveChanges();
            }
            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Task 1",
                    Created = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Inprogress
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
