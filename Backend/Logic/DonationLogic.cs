using AutoMapper;
using Backend.Models.BusinessModels;
using Backend.Models.DTOModels;
using Backend.Models.ViewModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Logic
{
    public class DonationLogic
    {
        private readonly IDonationRepository _repo;
        private readonly IMapper _mapper;
        public DonationLogic(IDonationRepository repo, IMapper mapper)
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

        public DonationViewModel SaveDonation(BuildingDonationViewModel donationViewModel)
        {
            Donation review = _mapper.Map<Donation>(donationViewModel);

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

        public List<DonationViewModel> SaveDonations(MapDonationViewModel donationViewModel)
        {
            List<DonationDTO> savedDonations = new List<DonationDTO>();

            foreach (BuildingDonationViewModel buildingDonation in donationViewModel.Donations)
            {
                Donation donation = _mapper.Map<Donation>(buildingDonation);
                donation.User = new User
                {
                    Id = donationViewModel.UserId
                };

                if (donation == null)
                {
                    throw new ArgumentNullException();
                }

                if (donation.Amount == 0 || donation.Building.Id == 0 || donation.User.Id == 0)
                {
                    throw new InvalidOperationException();

                }

                DonationDTO donationDTO = _repo.SaveDonation(_mapper.Map<DonationDTO>(donation));

                if (donationDTO.Id == 0)
                {
                    throw new DbUpdateException();
                }

                savedDonations.Add(donationDTO);
            }

            return _mapper.Map<List<DonationViewModel>>(_mapper.Map<List<Donation>>(savedDonations));
        }
    }
}
