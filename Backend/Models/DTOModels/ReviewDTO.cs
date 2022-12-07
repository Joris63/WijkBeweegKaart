using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class ReviewDTO
    {
        [Key]
        public int Id { get; set; }
        public string review { get; set; }
        [ForeignKey("writer")]
        public int userId { get; set; }
        public UserDTO writer { get; set; }
        [ForeignKey("reviewedMap")]
        public int mapId { get; set; }
        public MapDTO reviewedMap { get; set; }
    }
}
