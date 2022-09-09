namespace CandyCrush_Solution
{
    public class Candy
    {
        public Candy(char name, int length)
        {
            this.Name = name;
            this.Length = length;
        }

        public char Name { get; set; }

        public int Length { get; set; }
    }
}
