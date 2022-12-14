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

        public List<DonationViewModel> GetDonationsByBuildingId(int id)
        {
            List<Donation> review = _mapper.Map<List<Donation>>(_repo.GetDonationsByBuildingId(id));

            if (review == null)
            {
                throw new KeyNotFoundException();
            }

            return _mapper.Map<List<DonationViewModel>>(review);
        }

        public DonationViewModel SaveDonation(BuildingDonationViewModel reviewViewModel)
        {
            Donation review = _mapper.Map<Donation>(reviewViewModel);

            if (review == null)
            {
                throw new ArgumentNullException();
            }

            if (review.Amount == 0 || review.Building.Id == 0 || review.User.Id == 0)
            {
                throw new InvalidOperationException();

            }

            DonationDTO reviewdto = _repo.SaveDonation(_mapper.Map<DonationDTO>(review));

            if (reviewdto.Id == 0)
            {
                throw new DbUpdateException();
            }

            return _mapper.Map<DonationViewModel>(_mapper.Map<Donation>(reviewdto));
        }
    }
}
