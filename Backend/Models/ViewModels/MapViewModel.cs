namespace Backend.Models.ViewModels
{
    public class MapViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public LocationViewModel Loction { get; set; }
        public ICollection<BuildingViewModel> PlacedBuildings { get; set; }

        public MapViewModel()
        {

        }
    }
}
