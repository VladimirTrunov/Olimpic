namespace Circling_Solution
{
    public class Circling
    {
        public Circling(int radius, int[,] segments)
        {
            this.Radius = radius;
            this.Segments = segments;
        }

        public int Radius { get; set; }

        public int[,] Segments { get; set; }
    }
}