using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class MapDTO
    {
        [Key]
        public int Id { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public ICollection<BuildingDTO> placedBuildings { get; set; }

    }
}
