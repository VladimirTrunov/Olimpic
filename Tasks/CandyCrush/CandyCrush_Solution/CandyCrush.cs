namespace CandyCrush_Solution
{
    // Write a function to crush candy in a one dimensional board.
    // In candy crushing games, groups of like items are removed from the board.In this problem, any sequence of 3 or more like items should be removed and any items adjacent to that sequence should now be considered adjacent to each
    //other. This process should be repeated as many times as possible.

    //## Sample inputs - Expected outputs
    //* ABBBCC  -> ACC
    //* ABCCCBB -> A
    //* ABCCCBBAAC -> C

    using System.Text;
    
    public static class CandyCrush
    {
        public static List<Candy> GetCandies(string line)
        {
            List<Candy> candies = new List<Candy>();

            Candy candy = new Candy(line[0], 1);

            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] == candy.Name)
                {
                    candy.Length++;
                }
                else
                {
                    candies.Add(candy);
                    candy = new Candy(line[i], 1);
                }
            }

            candies.Add(candy);

            return candies;
        }

        public static string GetLineFromCandies(List<Candy> candies)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < candies.Count; i++)
            {
                stringBuilder.Append(new string(candies[i].Name, candies[i].Length));
            }

            return stringBuilder.ToString();
        }

        public static List<Candy> RemoveFullCandies(List<Candy> candies)
        {
            return (from g in candies
                    where g.Length < 3
                    select g).ToList();
        }

        public static string CrushCandies(string initialLine)
        {
            List<Candy> candies = GetCandies(initialLine);
            List<Candy> remainedCandies = RemoveFullCandies(candies);

            if (candies.Count == remainedCandies.Count)
            {
                return GetLineFromCandies(remainedCandies);
            }
            else
            {
                string remainedLine = GetLineFromCandies(remainedCandies);
                return CrushCandies(remainedLine);
            }
        }
    }
}