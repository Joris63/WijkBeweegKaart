namespace Backend.Models.BusinessModels
{
    public class Building
    {
        public int Id { get; set; }
        public Map Map { get; set; }
        public double Rotation { get;  set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int BuildingType { get; set; }

        public Building()
        {

        }
        public Building(int x, int y, int buildingType, float rotation)
        {
            this.X = x;
            this.Y = y;
            this.BuildingType = buildingType;
            this.Rotation = rotation;
        }
    }
}
