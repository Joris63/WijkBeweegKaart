﻿namespace Backend.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public MapViewModel[] CreatedMaps { get; set; }
        public ICollection<DonationViewModel> WrittenReviews { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public int Coins { get; set; }
        public Roles Role { get; set; }

        public UserViewModel(int id, MapViewModel[] createdMaps, ICollection<DonationViewModel> writtenReviews, string username, string password, string? email, int coins)
        {
            Id = id;
            this.CreatedMaps = createdMaps ?? new MapViewModel[2];
            this.WrittenReviews = writtenReviews;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Coins = coins;
        }

        public bool HasCreatedMap
        {
            get { return CreatedMaps.Any(m => m != null); }
        }
    }
}
