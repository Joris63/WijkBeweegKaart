namespace Backend.Models.BusinessModels
{
    public class User
    {
        public int Id { get; set; }
        public Map[] CreatedMaps { get; set; }
        public ICollection<Donation> MadeDonations { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public int Coins { get; set; }
        public Roles Role { get; set; }

        public User()
        {

        }

        public bool HasCreatedMap
        {
            get { return CreatedMaps.Any(); }
        }

        public void HashPassword()
        {
            Password = BCrypt.Net.BCrypt.HashPassword(Password);
        }
    }
}
