namespace Backend.Models.ViewModels
{
    public class UserLevelViewModel
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; }
        public LevelViewModel Level { get; set; }

        public UserLevelViewModel(UserViewModel user, LevelViewModel level)
        {
            this.User = user;
            this.Level = level;
        }
    }
}
