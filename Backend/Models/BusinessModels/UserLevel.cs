namespace Backend.Models.BusinessModels
{
    public class UserLevel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Level Level { get; set; }

        public UserLevel()
        {

        }
        public UserLevel(User user, Level level)
        {
            this.User = user;
            this.Level = level;
        }
    }
}
