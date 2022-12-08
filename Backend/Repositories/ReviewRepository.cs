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
            return _context.Reviews.Where(r => r.reviewedMap.Id == id).ToList();
        }

        public ReviewDTO SaveReview(ReviewDTO review)
        {
            ReviewDTO newReview = new ReviewDTO()
            {
                review = review.review,
                userId = review.userId,
                mapId = review.mapId
            };

            _context.Reviews.Add(newReview);
            _context.SaveChanges();

            return newReview;
        }
    }
}
