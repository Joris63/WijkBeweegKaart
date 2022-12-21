using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class PointDTO
    {
        [Key]
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        [ForeignKey("Region")]
        public int RegionId { get; set; }
        public RegionDTO Region { get; set; }
    }
}
