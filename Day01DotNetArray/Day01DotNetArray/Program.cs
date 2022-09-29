using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01DotNetArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // possibly a jagged array, only the first dimension is allocated
            int[][] twoDimInt = new int[4][];
            // rectangular array
            int[,] twoDimIntRectangular = new int[4, 3];
            int[,,] threeDimIntRect = new int[4, 3, 2]; // 3D: 4 x 3 x 2 size
            int[,] data2dInts = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 }, { 8, 11 }, { 9, 1 } };
            //int[,] test = { [ 1, 2 ], [ 3, 4 ], [ 5, 6 ], [ 7, 18 ] };

            float sum = 0;
            double dRs = 0;
            float fRs = 0;

            for (int i = 0; i < data2dInts.GetLength(0); i++)
            {
                
                for(int j = 0; j < data2dInts.GetLength(1); j++)
                {
                    sum += data2dInts[i, j];
                }

            }

            dRs = sum / data2dInts.Length;
            fRs = sum / data2dInts.Length;
            Console.WriteLine(fRs);
            Console.WriteLine(dRs);
            Console.WriteLine(sum / data2dInts.Length);

        }
    }
}
