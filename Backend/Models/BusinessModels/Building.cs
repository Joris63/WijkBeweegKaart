namespace Backend.Models.BusinessModels
{
    public class Building
    {
        private float rotation;
        private int x, y, type;

        public Building(int x, int y, int type, float rotation)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            this.rotation = rotation;
        }
    }
}
