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

        public ReviewViewModel SaveReview(ReviewViewModel reviewViewModel)
        {
            Review review = _mapper.Map<Review>(reviewViewModel);

            if (review != null)
            {
                if (review.review != null)
                {
                    ReviewDTO reviewdto = _repo.SaveReview(_mapper.Map<ReviewDTO>(review));

                    if (reviewdto.Id > 0)
                    {
                        return _mapper.Map<ReviewViewModel>(_mapper.Map<Review>(reviewdto));
                    }
                    else
                    {
                        throw new DbUpdateException();
                    }
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            throw new ArgumentNullException();
        }
    }
}
