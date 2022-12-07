using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Logic
{
    public class ReviewLogic
    {
        private readonly IReviewRepository _repo;
        private readonly IMapper _mapper;
        public ReviewLogic(IReviewRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<ReviewViewModel> GetReviewsByMapId(int id)
        {
            List<Review> review = _mapper.Map<List<Review>>(_repo.GetReviewsByMapId(id));

            if (review == null)
            {
                throw new KeyNotFoundException();
            }

            return _mapper.Map<List<ReviewViewModel>>(review);
        }

        public ReviewViewModel SaveReview(ReviewMapViewModel reviewViewModel)
        {
            Review review = _mapper.Map<Review>(reviewViewModel);

            if (review == null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(review.review) || review.reviewedMap.Id == 0 || review.writer.Id == 0)
            {
                throw new InvalidOperationException();

            }

            ReviewDTO reviewdto = _repo.SaveReview(_mapper.Map<ReviewDTO>(review));

            if (reviewdto.Id == 0)
            {
                throw new DbUpdateException();
            }

            return _mapper.Map<ReviewViewModel>(_mapper.Map<Review>(reviewdto));
        }
    }
}
