﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOModels
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? email { get; set; }
        public int coins { get; set; }
        public MapDTO[] createdMaps { get; set; }
        public ICollection<ReviewDTO> writtenReviews { get; set; }
        public ICollection<LevelDTO> levels { get; set; }
    }
}
