namespace Backend.Models.BusinessModels
{
    public class UserLevelViewModel
    {
        public UserViewModel user { get; set; }
        public LevelViewModel level { get; set; }

        public UserLevelViewModel(UserViewModel user, LevelViewModel level)
        {
            this.user = user;
            this.level = level;
        }
    }
}
