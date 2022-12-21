﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class MapDTO
    {
        [Key]
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; }
        [ForeignKey("MapCreator")]
        public int UserId { get; set; }
        public UserDTO MapCreator { get; set; }
        public ICollection<BuildingDTO> PlacedBuildings { get; set; }
        public ICollection<RegionDTO> Regions { get; set; }

    }
}
