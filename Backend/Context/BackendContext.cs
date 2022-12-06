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
            modelBuilder.Entity<UserDTO>().HasMany(u => u.createdMaps).WithOne(m => m.mapCreator).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
