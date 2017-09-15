using Microsoft.EntityFrameworkCore;
using ItineraryAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ItineraryAPI.Data
{
    public class ItineraryAPIContext : IdentityDbContext<User>
    {
        public ItineraryAPIContext(DbContextOptions<ItineraryAPIContext> options)
            : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Guides> Guides { get; set; }
        public DbSet<UserEvents> UserEvents { get; set; }
        public DbSet<UserGuides> UserGuides { get; set; }
    }
}
