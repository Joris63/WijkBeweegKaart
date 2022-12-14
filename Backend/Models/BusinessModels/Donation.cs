namespace Backend.Models.BusinessModels
{
    public class Donation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Building Building { get; set; }
        public int Amount { get; set; }

        public Donation()
        {

        }
    }
}
