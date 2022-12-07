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

        public UserViewModel(MapViewModel[] createdMaps, ICollection<ReviewViewModel> writtenReviews, string username, string password, string? email)
        {
            this.createdMaps = createdMaps ?? new MapViewModel[2];
            this.writtenReviews = writtenReviews;
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public bool HasCreatedMap
        {
            get { return createdMaps.Any(); }
        }
    }
}
