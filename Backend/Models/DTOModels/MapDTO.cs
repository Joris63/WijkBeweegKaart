using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class MapDTO
    {
        [Key]
        public int Id { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        [ForeignKey("mapCreator")]
        public int userId { get; set; }
        public UserDTO mapCreator { get; set; }
        public ICollection<BuildingDTO> placedBuildings { get; set; }

    }
}
