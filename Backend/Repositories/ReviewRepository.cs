using Backend.Context;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BackendContext _context;

        public ReviewRepository(BackendContext context)
        {
            _context = context;
        }

        public List<ReviewDTO> GetReviewsByMapId(int id)
        {
            return _context.Reviews.Where(r => r.ReviewedMap.Id == id).ToList();
        }

        public ReviewDTO SaveReview(ReviewDTO review)
        {
            ReviewDTO newReview = new ReviewDTO()
            {
                Review = review.Review,
                UserId = review.UserId,
                MapId = review.MapId
            };

            _context.Reviews.Add(newReview);
            _context.SaveChanges();

            return newReview;
        }
    }
}
