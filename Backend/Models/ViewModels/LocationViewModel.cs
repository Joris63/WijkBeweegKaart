namespace Backend.Models.ViewModels
{
    public class LocationViewModel
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; }
        public ICollection<RegionViewModel> Regions { get; set; }
    }
}
