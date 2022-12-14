using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class BuildingDTO
    {
        [Key]
        public int Id { get; set; }
        public float Rotation { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int BuildingType { get; set; }
        public int CoinAmount { get; set; }
        [ForeignKey("Map")]
        public int MapId { get; set; }
        public MapDTO Map { get; set; }

    }
}
