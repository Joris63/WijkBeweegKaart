using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models.DTOModels
{
    public class BuildingDTO
    {
        [Key]
        public int Id { get; set; }
        public double Rotation { get; set; }
        public double X { get; set; }
        public double Z { get; set; }
        public int BuildingType { get; set; }
        public int CoinAmount { get; set; }
        public string Name { get; set; }
        [ForeignKey("Map")]
        public int MapId { get; set; }
        public MapDTO Map { get; set; }

    }
}
