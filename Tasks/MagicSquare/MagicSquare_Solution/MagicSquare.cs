namespace MagicSquare_Solution
{
    public class MagicSquare
    {
        public MagicSquare(int[,] data)
        {
            this.Data = data;
        }

        public int[,] Data { get; set; }

        public static bool IsMagic(int[,] data)
        {
            if (data.GetLength(0) != 3 && data.GetLength(1) != 3)
            {
                return false;
            }

            int row1 = data[0, 0] + data[0, 1] + data[0, 2];
            int row2 = data[1, 0] + data[1, 1] + data[1, 2];
            int row3 = data[2, 0] + data[2, 1] + data[2, 2];

            int col1 = data[0, 0] + data[1, 0] + data[2, 0];
            int col2 = data[0, 1] + data[1, 1] + data[2, 1];
            int col3 = data[0, 2] + data[1, 2] + data[2, 2];

            int diag1 = data[0, 0] + data[1, 1] + data[2, 2];
            int diag2 = data[2, 0] + data[1, 1] + data[0, 2];

            return (new List<int> { row1, row2, row3, col1, col2, col3, diag1, diag2 }).Distinct().Count() == 1;
        }
    }
}