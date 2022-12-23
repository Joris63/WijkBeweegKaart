namespace Backend.Models.ViewModels
{
    public class BuildingViewModel
    {
        public int Id { get; set; }
        public double Rotation { get; set; }
        public double X { get; set; }
        public double Z { get; set; }
        public int BuildingType { get; set; }
        public int CoinAmount { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public ICollection<DonationViewModel> Donations { get; set; }

        public BuildingViewModel()
        {

        }
    }
}
