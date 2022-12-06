using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class ReviewDTO
    {
        [Key]
        public int Id { get; set; }
        public string review { get; set; }
        public UserDTO writer { get; set; }
        public MapDTO reviewedMap { get; set; }
    }
}
