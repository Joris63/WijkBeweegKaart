using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class LocationDTO
    {
        [Key]
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; }
        public ICollection<RegionDTO> Regions { get; set; }
    }
}
