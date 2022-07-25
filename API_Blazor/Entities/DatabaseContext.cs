using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Blazor.Entities
{
    public class DatabaseContext : IdentityDbContext<User, Role, Guid>
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Task> Tasks { get; set; }
    }
}
