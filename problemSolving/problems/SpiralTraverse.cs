using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
    public static class SpiralTraverse
    {
        public static List<int> GetSpiralTraverse(int[,] array)
        {
            int x = 0;int y = 0;
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            while (y<=cols)
            {
                Console.WriteLine(array[x, y]);
                //if (y + 1 > cols )
                //{
                //    rows = rows - 1;
                //    //y = y - 1;
                //    x = x + 1;
                //}
                //else
                //{
                //    y++;

                //}
                //if (y < rows-1)
                //{
                //    y++;

                //}
                if (y+1 < cols)
                {
                    y++;
                }
                if (y + 1 == cols)
                {
                    Console.WriteLine(array[x, y]);
                    while (x + 1 != rows)
                    {
                        x++;
                        Console.WriteLine(array[x,y]);
                    }
                }
                if(y+1==cols && x + 1 == rows)
                {
                    while (y!=0)
                    {
                        y--;
                        Console.WriteLine(array[x,y]);
                    }
                }
                if(y==0 && x+1==rows)
                {
                    rows = rows -2;
                    cols = cols - 2;
                    //if (rows % 2 == 0)
                    //    x = x + 1;

                    while (x >= cols)
                    {
                        x--;    
                        Console.WriteLine(array[x,y]);
                    }
                    y++;
                }
            }
            // Write your code here.
            return new List<int>();
        }
    }
}
