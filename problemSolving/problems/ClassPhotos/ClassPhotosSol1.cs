using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.ClassPhotos
{
    class ClassPhotosSol1
    {
        // O(nlog(n)) time | O(1) space - where n is the number of students
        public bool ClassPhotos(List<int> redShirtHeights, List<int> blueShirtHeights)
        {
            redShirtHeights.Sort((a, b) => b.CompareTo(a));
            blueShirtHeights.Sort((a, b) => b.CompareTo(a));
            string shirtColorInFirstRow =
            (redShirtHeights[0] < blueShirtHeights[0]) ? "RED" : "BLUE";
            for (int idx = 0; idx < redShirtHeights.Count; idx++)
            {
                int redShirtHeight = redShirtHeights[idx];
                int blueShirtHeight = blueShirtHeights[idx];
                if (shirtColorInFirstRow == "RED")
                {
                    if (redShirtHeight >= blueShirtHeight)
                    {
                        return false;
                    }
                }
                else
                {
                    if (blueShirtHeight >= redShirtHeight)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
