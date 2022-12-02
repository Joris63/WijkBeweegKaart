namespace Backend.Models.BusinessModels
{
    public class UserLevel
    {
        public User user { get; set; }
        public Level level { get; set; }

        public UserLevel(User user, Level level)
        {
            this.user = user;
            this.level = level;
        }
    }
}
