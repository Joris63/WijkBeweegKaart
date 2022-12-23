using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public int Coins { get; set; }
        public ICollection<MapDTO> CreatedMaps { get; set; }
        public Roles Role { get; set; }
        public ICollection<DonationDTO> MadeDonations { get; set; }
        public ICollection<LevelDTO> Levels { get; set; }
    }
}
