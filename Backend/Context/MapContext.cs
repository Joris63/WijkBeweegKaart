using Backend.Models.DTOModels;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class MapContext : DbContext
    {
        public MapContext(DbContextOptions<MapContext> options) : base(options)
        {

        }

        public DbSet<BuildingDTO> Buildings { get; set; }
    }
}
