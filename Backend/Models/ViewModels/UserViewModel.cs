namespace Backend.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public MapViewModel[] createdMaps { get; set; }
        public ICollection<ReviewViewModel> writtenReviews { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? email { get; set; }
        public int coins { get; set; }

        public UserViewModel(int id, MapViewModel[] createdMaps, ICollection<ReviewViewModel> writtenReviews, string username, string password, string? email, int coins)
        {
            Id = id;
            this.createdMaps = createdMaps ?? new MapViewModel[2];
            this.writtenReviews = writtenReviews;
            this.username = username;
            this.password = password;
            this.email = email;
            this.coins = coins;
        }

        public bool HasCreatedMap
        {
            get { return createdMaps.Any(m => m != null); }
        }
    }
}
