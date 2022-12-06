using Backend.Models.BusinessModels;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? email { get; set; }
        public Map[] createdMaps { get; set; }
        public ICollection<Review> writtenReviews { get; set; }
    }
}
