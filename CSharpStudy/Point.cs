namespace CSharpStudy
{
    #region C# Intermediate

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(Point newLocation)
        {
            Move(newLocation.X, newLocation.Y); //if you pass null, exception
                                                // this.X = newLocation.X;
                                                // this.Y = newLocation.Y;
        }
    }

    #endregion
}
