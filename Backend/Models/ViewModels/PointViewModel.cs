namespace Backend.Models.ViewModels
{
    public class PointViewModel
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public PointViewModel()
        {

        }
    }
}
