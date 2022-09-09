namespace Circling_Solution
{
    public class Segment
    {
        public Segment(CirclePoint point1, CirclePoint point2)
        {
            if (point1.Angle == point2.Angle)
            {
                throw new ArgumentException($"Two points have the same angle ({point1.Angle}). Unable to create a segment.");
            }

            if (point1.Angle < point2.Angle)
            {
                this.Point1 = point1;
                this.Point2 = point2;
            }
            else
            {
                this.Point2 = point1;
                this.Point1 = point2;
            }
        }

        public CirclePoint Point1 { get; set; }

        public CirclePoint Point2 { get; set; }
    }
}
