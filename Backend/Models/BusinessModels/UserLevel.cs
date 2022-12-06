namespace Backend.Models.BusinessModels
{
    public class UserLevel
    {
        public int Id { get; set; }
        public User user { get; set; }
        public Level level { get; set; }

        public UserLevel(User user, Level level)
        {
            this.user = user;
            this.level = level;
        }
    }
}
