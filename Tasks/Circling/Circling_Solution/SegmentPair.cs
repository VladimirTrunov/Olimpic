namespace Circling_Solution
{
    public class SegmentPair
    {
        public SegmentPair(Segment segment1, Segment segment2)
        {
            this.Segment1 = segment1;
            this.Segment2 = segment2;
        }

        public Segment Segment1 { get; set; }

        public Segment Segment2 { get; set; }

        public bool AreCrossing()
        {
            List<CirclePoint> circlePoints = new List<CirclePoint> { this.Segment2.Point1, this.Segment2.Point2 };
            List<CirclePoint> pointsInRange = (from g in circlePoints
                                               where g.Angle > this.Segment1.Point1.Angle && g.Angle < this.Segment1.Point2.Angle
                                               select g).ToList();

            if (pointsInRange.Count == 1)
            {
                return true;
            }

            return false;
        }
    }
}
