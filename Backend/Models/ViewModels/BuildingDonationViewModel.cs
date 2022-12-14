namespace Backend.Models.ViewModels
{
    public class BuildingDonationViewModel
    {
        public int UserId { get; set; }
        public int BuildingId { get; set; }
        public int Amount { get; set; }
        public BuildingDonationViewModel()
        {

        }
    }
}
