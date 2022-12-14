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

        public List<DonationDTO> GetDonationsByBuildingId(int id)
        {
            return _context.Reviews.Where(r => r.BuildingId == id).ToList();
        }

        public DonationDTO SaveDonation(DonationDTO review)
        {
            DonationDTO newReview = new DonationDTO()
            {
                Amount = review.Amount,
                UserId = review.UserId,
                BuildingId = review.BuildingId
            };

            _context.Reviews.Add(newReview);
            _context.SaveChanges();

            return newReview;
        }
    }
}
