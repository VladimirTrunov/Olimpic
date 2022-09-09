using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquare_Solution
{
    public class MagicSquaresProvider
    {
        static MagicSquaresProvider()
        {
            GetMagicSquares();
        }

        public static List<MagicSquare> MagicSquares = new List<MagicSquare>();

        public static void GetMagicSquares()
        {
            List<int> set = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[,] data = new int[3, 3];

            FindMagicSquares(data, 0, 0, set);
        }

        public static void FindMagicSquares(int[,] data, int i, int j, List<int> set)
        {
            for (int k = 0; k < set.Count; k++)
            {
                data[i, j] = set[k];
                
                if (i == 2 && j == 2)
                {
                    bool isMagic = MagicSquare.IsMagic(data);
                    if (isMagic)
                    {
                        MagicSquares.Add(new MagicSquare(data));
                    }

                    return;
                }
                else
                {
                    j++;

                    if (j == 3)
                    {
                        i++;
                        j = 0;
                    }

                    List<int> newSet = (from g in set
                                        where g != set[k]
                                        select g).ToList();

                    FindMagicSquares(data, i, j, newSet);

                    j--;
                    if (j == -1)
                    {
                        i--;
                        j = 2;
                    }
                }
            }
        }

        public static int GetDistanceToNearestMagicDquare(int[,] data)
        {
            int distance = 100000;

            for (int k = 0; k < MagicSquares.Count; k++)
            {
                int currentDistance = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        currentDistance += Math.Abs(data[i, j] - MagicSquares[k].Data[i, j]);
                    }
                }

                if (currentDistance < distance)
                {
                    distance = currentDistance;
                }
            }

            return distance;
        }
    }
}
