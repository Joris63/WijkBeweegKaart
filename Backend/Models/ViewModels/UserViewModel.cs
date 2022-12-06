using Backend.Models.ViewModels;

namespace Backend.Models.BusinessModels
{
    public class UserViewModel
    {
        public MapViewModel[] createdMaps { get; set; }
        public ICollection<ReviewViewModel> writtenReviews { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? email { get; set; }

        public UserViewModel(MapViewModel[] createdMaps, ICollection<ReviewViewModel> writtenReviews, string username, string password, string? email)
        {
            this.createdMaps = createdMaps;
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
