using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class RegionDTO
    {
        public int Id { get; set; }
        public ICollection<PointDTO> Points { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public LocationDTO Location { get; set; }
    }
}
