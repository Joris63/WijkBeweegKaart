﻿namespace Backend.Models.BusinessModels
{
    public class UserLevel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Level Level { get; set; }

        public UserLevel()
        {

        }
    }
}
