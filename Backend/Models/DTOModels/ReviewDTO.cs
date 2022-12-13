using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class ReviewDTO
    {
        [Key]
        public int Id { get; set; }
        public string Review { get; set; }
        [ForeignKey("Writer")]
        public int UserId { get; set; }
        public UserDTO Writer { get; set; }
        [ForeignKey("ReviewedMap")]
        public int MapId { get; set; }
        public MapDTO ReviewedMap { get; set; }
    }
}
