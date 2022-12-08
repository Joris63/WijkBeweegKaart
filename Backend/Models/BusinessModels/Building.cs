namespace Backend.Models.BusinessModels
{
    public class Building
    {
        public int Id { get; set; }
        public Map map { get; set; }
        public double rotation { get;  set; }
        public int x { get; set; }
        public int y { get; set; }
        public int buildingType { get; set; }

        public Building()
        {

        }
        public Building(int x, int y, int buildingType, float rotation)
        {
            this.x = x;
            this.y = y;
            this.buildingType = buildingType;
            this.rotation = rotation;
        }
    }
}
