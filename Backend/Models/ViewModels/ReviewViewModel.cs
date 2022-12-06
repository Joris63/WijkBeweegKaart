namespace Backend.Models.ViewModels
{
    public class ReviewViewModel
    {
        public UserViewModel writer { get; set; }
        public MapViewModel reviewedMap { get; set; }
        public string review { get; set; }

        public ReviewViewModel(UserViewModel writer, MapViewModel reviewedMap, string review)
        {
            this.writer = writer;
            this.reviewedMap = reviewedMap;
            this.review = review;
        }
    }
}
