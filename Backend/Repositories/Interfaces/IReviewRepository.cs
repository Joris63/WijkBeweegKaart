using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        public List<DonationDTO> GetDonationsByBuildingId(int id);
        public DonationDTO SaveDonation(DonationDTO review);
    }
}
