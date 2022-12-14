using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class DonationDTO
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public BuildingDTO Building { get; set; }
    }
}
