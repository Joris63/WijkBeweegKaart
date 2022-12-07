using Backend.Context;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            _context.Reviews.Add(review);
            _context.SaveChanges();

            return review;
        }
    }
}
