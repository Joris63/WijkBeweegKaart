namespace Backend.Models.ViewModels
{
    public class MapDonationViewModel
    {
        public int UserId { get; set; }
        public List<BuildingDonationViewModel> Donations { get; set; }

        public MapDonationViewModel()
        {

        }
    }
}
