using Backend.Context;
using Backend.Models.DTOModels;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BackendContext _context;

        public DonationRepository(BackendContext context)
        {
            _context = context;
        }

        public List<DonationDTO> GetDonationsByBuildingId(int id)
        {
            return _context.Donations.Where(d => d.BuildingId == id).Include(d => d.User).Include(d => d.Building).ToList();
        }

        public DonationDTO SaveDonation(DonationDTO donation)
        {
            DonationDTO newReview = new DonationDTO()
            {
                Amount = donation.Amount,
                UserId = donation.UserId,
                BuildingId = donation.BuildingId
            };

            BuildingDTO building = _context.Buildings.FirstOrDefault(building => building.Id == donation.BuildingId);
            building.CoinAmount += donation.Amount;

            _context.Donations.Add(newReview);
            _context.Buildings.Update(building);
            _context.SaveChanges();

            return newReview;
        }
    }
}
