using Backend.Models.BusinessModels;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories
{
    public class MapRepository : IMapRepository
    {
        public List<Building> GetBuildings() 
        {
            List<Building> list = new List<Building>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Building b = new Building(i, j, 2, 15.913f);
                    list.Add(b);

                }
            }
            return list;
        }
    }
}
