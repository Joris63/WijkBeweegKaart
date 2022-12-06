using Backend.Models.DTOModels;

namespace Backend.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        public List<ReviewDTO> GetReviewsByMapId(int id);
        public ReviewDTO SaveReview(string text, UserDTO writer, MapDTO map);
    }
}
