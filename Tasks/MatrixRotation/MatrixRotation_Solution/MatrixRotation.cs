namespace MatrixRotation_Solution
{
    // https://www.hackerrank.com/challenges/matrix-rotation-algo/problem?isFullScreen=true
    public class MatrixRotation
    {
        public MatrixRotation(int[,] matrix)
        {
            this.Matrix = matrix;
        }

        public int[,] Matrix { get; set; }

        public void Rotate(int steps)
        {
            if (steps < 0)
            {
                throw new ArgumentException($"Steps ({steps}) is less than zero.");
            }

            List<Chain> chains = GetChainsFromArray(this.Matrix); 
            foreach (Chain chain in chains)
            {
                int optimizedSteps = steps % chain.Items.Count;
                for (int i = 0; i < optimizedSteps; i++)
                {
                    chain.MoveForward();
                }
            }

            this.Matrix = GetUpdatedArrayWithChains(this.Matrix, chains);
        }

        public static int GetChainsCount(int lengthRow, int lengthColumn)
        {
            if (lengthRow < lengthColumn)
            {
                return lengthRow / 2;
            }

            return lengthColumn / 2;
        }

        public static List<Chain> GetChainsFromArray(int[,]matrix)
        {
            int lengthRow = matrix.GetLength(0);
            int lengthColumn = matrix.GetLength(1);

            int chainsCount = GetChainsCount(lengthRow, lengthColumn);

            List<Chain> chains = new List<Chain>();

            for (int offset = 0; offset < chainsCount; offset++)
            {
                List<Item> items = new List<Item>();
                
                for (int i = offset; i < lengthRow - offset; i++)
                {
                    items.Add(new Item(i, offset, matrix[i, offset]));
                }

                for (int i = offset; i < lengthColumn - 1 - offset; i++)
                {
                    items.Add(new Item(lengthRow - offset - 1, i + 1, matrix[lengthRow - offset - 1, i + 1]));
                }

                for (int i = offset; i < lengthRow - 1 - offset; i++)
                {
                    items.Add(new Item(lengthRow - i - 2, lengthColumn - offset - 1, matrix[lengthRow - i - 2, lengthColumn - offset - 1]));
                }

                for (int i = offset; i < lengthColumn - 2 - offset; i++)
                {
                    items.Add(new Item(offset, lengthColumn - i - 2, matrix[offset, lengthColumn - i - 2]));
                }

                chains.Add(new Chain(items));
            }

            return chains;
        }

        public static int[,] GetUpdatedArrayWithChains(int[,]matrix, List<Chain> chains)
        {
            List<Item> allChainItems = new List<Item>();
            foreach(Chain chain in chains)
            {
                allChainItems.AddRange(chain.Items);
            }

            int lengthRow = matrix.GetLength(0);
            int lengthColumn = matrix.GetLength(1);

            int[,] result = new int[lengthRow, lengthColumn];

            for (int i = 0; i < lengthRow; i++)
            {
                for (int j = 0; j < lengthColumn; j++)
                {
                    Item? relatedItem = (from g in allChainItems
                                         where g.Row == i && g.Col == j
                                         select g).FirstOrDefault();

                    if (relatedItem != null)
                    {
                        result[i, j] = relatedItem.Value;
                    }
                    else
                    {
                        result[i, j] = matrix[i,j];
                    }
                }
            }

            return result;
        }
    }
}