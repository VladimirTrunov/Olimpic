namespace Circling_Solution
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        //public Point(CirclePoint circlePoint)
        //{
        //    this.X = circlePoint.Radius * Math.Cos(circlePoint.Angle);
        //    this.Y = circlePoint.Radius * Math.Sin(circlePoint.Angle);
        //}

        public Point()
        {
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}
