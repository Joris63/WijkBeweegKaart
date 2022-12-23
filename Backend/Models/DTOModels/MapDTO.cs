using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class MapDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Location")]
        public int LocationId{ get; set; }
        public LocationDTO Location { get; set; }
        [ForeignKey("MapCreator")]
        public int UserId { get; set; }
        public UserDTO MapCreator { get; set; }
        public ICollection<BuildingDTO> PlacedBuildings { get; set; }
    }
}
