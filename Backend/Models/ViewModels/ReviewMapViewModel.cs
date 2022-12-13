namespace Backend.Models.ViewModels
{
    public class ReviewMapViewModel
    {
        public int UserId { get; set; }
        public int MapId { get; set; }
        public string Review { get; set; }
        public ReviewMapViewModel()
        {

        }
    }
}
