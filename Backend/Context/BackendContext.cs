using Backend.Models.DTOModels;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class BackendContext : DbContext
    {
        public BackendContext(DbContextOptions<BackendContext> options) : base(options)
        {

        }

        public DbSet<BuildingDTO> Buildings { get; set; }
        public DbSet<MapDTO> Maps { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<LevelDTO> Levels { get; set; }
        public DbSet<UserLevelDTO> UserLevels { get; set; }
        public DbSet<ReviewDTO> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDTO>()
                .HasMany(u => u.createdMaps)
                .WithOne(m => m.mapCreator)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<UserDTO>().Property(u => u.coins).HasDefaultValue(0);

            modelBuilder.Entity<UserDTO>().HasMany(u => u.levels)
                .WithMany(l => l.users)
                .UsingEntity<UserLevelDTO>(
                ul => ul.HasOne(ul => ul.level)
                .WithMany().HasForeignKey(ul => ul.levelId),
                ul => ul.HasOne(ul => ul.user)
                .WithMany().HasForeignKey(ul => ul.userId));

            modelBuilder.Entity<UserLevelDTO>()
                .HasKey(x => new { x.userId, x.levelId });
        }
    }
}
