namespace Backend.Models.BusinessModels
{
    public class Review
    {
        public int Id { get; set; }
        public User Writer { get; set; }
        public Map ReviewedMap { get; set; }
        public string ReviewText { get; set; }

        public Review()
        {

        }
        public Review(User writer, Map reviewedMap, string review)
        {
            this.Writer = writer;
            this.ReviewedMap = reviewedMap;
            this.ReviewText = review;
        }
    }
}
