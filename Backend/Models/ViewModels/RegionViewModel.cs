namespace Backend.Models.ViewModels
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        public int MapId { get; set; }
        public ICollection<PointViewModel> Points { get; set; }
        public RegionViewModel()
        {

        }
    }
}
