using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class BuildingDTO
    {
        [Key]
        public int Id { get; set; }
        public float rotation { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int buildingType { get; set; }

        public MapDTO map { get; set; }

    }
}
