namespace Circling_Solution
{
    public class CirclePoint
    {
        private int _angle;

        private double _radius;

        public int Angle
        {
            get { return _angle; }
            set
            {
                if (value < 0 || value > 359)
                {
                    throw new ArgumentException($"Angle should be more or equal to 0 and less or equal to 359. The current value is '{value}'.");
                }

                _angle = value;
            }
        }

        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Radius should be more than 0. The current value is '{value}'.");
                }

                _radius = value;
            }
        }

        public Point GetPoint()
        {
            double x = this.Radius * Math.Cos(this.Angle);
            double y = this.Radius * Math.Sin(this.Angle);

            return new Point(x, y);
        }
    }
}
