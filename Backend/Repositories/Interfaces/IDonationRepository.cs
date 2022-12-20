using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface IDonationRepository
    {
        public List<DonationDTO> GetDonationsByBuildingId(int id);
        public DonationDTO SaveDonation(DonationDTO review);
    }
}
