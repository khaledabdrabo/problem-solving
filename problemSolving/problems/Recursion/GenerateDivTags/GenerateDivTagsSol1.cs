using System;
using System.Collections.Generic;
using System.Text;

namespace problemSolving.problems.GenerateDivTags
{
    class GenerateDivTagsSol1
    {
        // O((2n)!/((n!((n + 1)!)))) time | O((2n)!/((n!((n + 1)!)))) space -
        // where n is the input number
        public List<string> GenerateDivTags(int numberOfTags)
        {
            List<string> matchedDivTags = new List<string>();
            GenerateDivTagsFromPrefix(numberOfTags, numberOfTags, "", matchedDivTags);
            return matchedDivTags;
        }
        public void GenerateDivTagsFromPrefix(int openingTagsNeeded, int closingTagsNeeded,
        string prefix,
        List<string> result)
        {
            if (openingTagsNeeded > 0)
            {
                string newPrefix = prefix + "<div>";
                GenerateDivTagsFromPrefix(openingTagsNeeded - 1, closingTagsNeeded,
                newPrefix, result);
            }
            if (openingTagsNeeded < closingTagsNeeded)
            {
                string newPrefix = prefix + "</div>";
                GenerateDivTagsFromPrefix(openingTagsNeeded, closingTagsNeeded - 1,
                newPrefix, result);
            }
            if (closingTagsNeeded == 0)
            {
                result.Add(prefix);
            }
        }
    }
}
