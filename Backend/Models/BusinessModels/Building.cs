namespace Backend.Models.BusinessModels
{
    public class Building
    {
        public int Id { get; set; }
        public Map Map { get; set; }
        public double Rotation { get;  set; }
        public double X { get; set; }
        public double Z { get; set; }
        public int BuildingType { get; set; }
        public int CoinAmount { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }

        public Building()
        {

        }

        public void CalculateLevel()
        {
            Level = (int)Math.Floor((decimal)(CoinAmount / 50));
        }
    }
}
