namespace Backend.Models.BusinessModels
{
    public class Building
    {
        public float rotation { get;  set; }
        public int x { get; set; }
        public int y { get; set; }
        public int buildingType { get; set; }

        public Building(int x, int y, int buildingType, float rotation)
        {
            this.x = x;
            this.y = y;
            this.buildingType = buildingType;
            this.rotation = rotation;
        }
    }
}
