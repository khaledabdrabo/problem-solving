using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems
{
    public static class MonotonicArray
    {
        public static bool IsMonotonic(int[] array)
        {

            var direction = false;
            if (array.Length == 1)
                return true;
            if (array.Length > 1)
            {
                var firstValue = array[0];
                var secondValue = array[1];
                

                if (secondValue > firstValue)
                {
                    direction = true;
                }
                if (firstValue == secondValue)
                {
                    for (int i = 2; i < array.Length; i++)
                    {
                        if (array[i] > secondValue)
                        {
                            direction = true;
                            break;
                        }
                        else
                        {
                            direction = false;
                            break;
                        }
                    }
                }
                if (direction)
                {
                    for (int i = 2; i < array.Length; i++)
                    {
                        if (array[i] < secondValue)
                            return false;
                        secondValue = array[i];
                    }
                    return true;
                }
                else
                {
                    for (int i = 2; i < array.Length; i++)
                    {
                        if (array[i] > secondValue)
                            return false;
                        secondValue = array[i];
                    }
                    return true;
                }

            }
            // Write your code here.
            return true;
        }
    }
}
