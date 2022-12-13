namespace Backend.Models.BusinessModels
{
    public class User
    {
        public int Id { get; set; }
        public Map[] CreatedMaps { get; set; }
        public ICollection<Review> WrittenReviews { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public int Coins { get; set; }
        public Roles Role { get; set; }

        public User()
        {

        }
        public User(int id, Map[] createdMaps, ICollection<Review> writtenReviews, string username, string password, string? email, int coins, Roles role)
        {
            Id = id;
            this.CreatedMaps = createdMaps;
            this.WrittenReviews = writtenReviews;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Coins = coins;
            this.Role = role;
        }

        public bool HasCreatedMap
        {
            get { return CreatedMaps.Any(); }
        }
    }
}
