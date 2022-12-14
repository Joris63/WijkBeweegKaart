namespace Backend.Models.ViewModels
{
    public class BuildingViewModel
    {
        public int Id { get; set; }
        public float Rotation { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int BuildingType { get; set; }
        public int CoinAmount { get; set; }
        public int Level { get; set; }

        public BuildingViewModel()
        {

        }

        public BuildingViewModel(float rotation, int x, int y, int buildingType)
        {
            this.Rotation = rotation;
            this.X = x;
            this.Y = y;
            this.BuildingType = buildingType;
        }
    }
}
