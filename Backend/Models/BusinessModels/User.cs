namespace Backend.Models.BusinessModels
{
    public class User
    {
        public int Id { get; set; }
        public Map[] createdMaps { get; set; }
        public ICollection<Review> writtenReviews { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? email { get; set; }

        public User(Map[] createdMaps, ICollection<Review> writtenReviews, string username, string password, string? email)
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
