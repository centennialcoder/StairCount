using System;
using System.Collections.Generic;
using System.Text;

namespace Stair
{
    public static class StairRecursive
    {
        private static Dictionary<int, Dictionary<int, long>> dict = new Dictionary<int, Dictionary<int, long>>();

        public static long Val(int numBlocks)
        {
            return RecVal(numBlocks, numBlocks - 1);
        }

        private static long RecVal(int numBlocks, int maxHeight)
        {
            //allow last column with no blocks
            if (numBlocks == 0) return 1;

            //return 0 if we can't make a stair less than maxHeight for this # of blocks
            if (MaxStair.Max(maxHeight) < numBlocks) { return 0; }

            //known simple cases
            if (numBlocks <= 2) { return 1; }

            //use recursion
            long numCases = 0;
            for(int i=Math.Min(numBlocks, maxHeight); i > 0; i--)
            {
                //next stair column attempts i blocks
                long partial = GetPartial(numBlocks - i, i - 1);

                //if we have too many blocks for MaxHeight, then stop attempting any more
                if (partial == 0) break;

                numCases += partial;
            }
            return numCases;
        }

        private static long GetPartial(int numBlocks, int maxHeight)
        {
            //check already calculated partial results
            if (dict.ContainsKey(numBlocks))
            {
                if (dict[numBlocks].ContainsKey(maxHeight))
                {
                    return (dict[numBlocks])[maxHeight];
                }
            }
            else
                dict.Add(numBlocks, new Dictionary<int, long>());

            //insert new result into dictionary
            long partial = RecVal(numBlocks, maxHeight);
            (dict[numBlocks]).Add(maxHeight, partial);

            return partial;
        }

    }
}
