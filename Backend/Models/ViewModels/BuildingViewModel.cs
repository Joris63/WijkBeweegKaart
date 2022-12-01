namespace Backend.Models.ViewModels
{
    public class BuildingViewModel
    {
        public float rotation { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int buildingType { get; set; }

        public BuildingViewModel()
        {

        }

        public BuildingViewModel(float rotation, int x, int y, int buildingType)
        {
            this.rotation = rotation;
            this.x = x;
            this.y = y;
            this.buildingType = buildingType;
        }
    }
}
