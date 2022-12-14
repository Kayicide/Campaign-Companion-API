using Microsoft.EntityFrameworkCore;
using CampaignCompanionAPI.Data.Entities;

namespace CampaignCompanionAPI.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>().ToTable("Campaign");
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<Encounter>().ToTable("Encounter");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
