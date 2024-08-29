using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GameCatalogue.Models;

namespace GameCatalogue
{
    public class ApplicationDbContext : IdentityDbContext<User> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SystemRequirement> SystemRequirements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.SystemRequirement)
                .WithOne(sr => sr.Game)
                .HasForeignKey<SystemRequirement>(sr => sr.RequirementsId);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Reviews)
                .WithOne(r => r.Game)
                .HasForeignKey(r => r.GameId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Developers)
                .WithMany(d => d.Games)
                .UsingEntity(j => j.ToTable("GameDevelopers"));
        }

    }
}
