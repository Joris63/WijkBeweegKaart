namespace Backend.Models.ViewModels
{
    public class SaveRegionsViewModel
    {
        public int MapId { get; set; }
        public ICollection<RegionViewModel> Regions { get; set; }
    }
}
