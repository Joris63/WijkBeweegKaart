namespace Backend.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public UserViewModel Writer { get; set; }
        public MapViewModel ReviewedMap { get; set; }
        public string Review { get; set; }

        public ReviewViewModel(UserViewModel writer, MapViewModel reviewedMap, string review)
        {
            this.Writer = writer;
            this.ReviewedMap = reviewedMap;
            this.Review = review;
        }
    }
}
