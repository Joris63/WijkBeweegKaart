namespace Backend.Models.ViewModels
{
    public class SaveMapViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public ICollection<BuildingViewModel> PlacedBuildings { get; set; }

        public SaveMapViewModel()
        {

        }
    }
}
