namespace Backend.Models.BusinessModels
{
    public class Review
    {
        public int Id { get; set; }
        public User writer { get; set; }
        public Map reviewedMap { get; set; }
        public string review { get; set; }

        public Review()
        {

        }
        public Review(User writer, Map reviewedMap, string review)
        {
            this.writer = writer;
            this.reviewedMap = reviewedMap;
            this.review = review;
        }
    }
}
