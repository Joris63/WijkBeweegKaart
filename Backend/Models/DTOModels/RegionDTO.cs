using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class RegionDTO
    {
        public int Id { get; set; }
        public ICollection<PointDTO> Points { get; set; }
        [ForeignKey("Map")]
        public int MapId { get; set; }
        public MapDTO Map { get; set; }
    }
}
