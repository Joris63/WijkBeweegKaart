namespace Backend.Models.BusinessModels
{
    public class Building
    {
        public int Id { get; set; }
        public Map Map { get; set; }
        public double Rotation { get;  set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int BuildingType { get; set; }
        public int CoinAmount { get; set; }
        public int Level { get; set; }

        public Building()
        {
            CalculateLevel();
        }

        private void CalculateLevel()
        {
            Level = (int)Math.Floor((decimal)(CoinAmount / 50));
        }
    }
}
