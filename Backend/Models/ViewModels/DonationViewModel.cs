namespace Backend.Models.ViewModels
{
    public class DonationViewModel
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; }
        public BuildingViewModel Building { get; set; }
        public int Amount { get; set; }

        public DonationViewModel(UserViewModel user, BuildingViewModel Building, int amount)
        {
            this.User = user;
            this.Building = Building;
            this.Amount = amount;
        }
    }
}
