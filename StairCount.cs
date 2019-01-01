using System;
using System.Collections.Generic;
using System.Text;

namespace Stair
{
    public static class StairCount
    {
        private static Dictionary<int, Dictionary<int, long>> dict = new Dictionary<int, Dictionary<int, long>>();

        public static long Count(int numBlocks)
        {
            return CountRecursive(numBlocks, numBlocks - 1);
        }

        private static long CountRecursiveOriginal(int numBlocks, int maxHeight)
        {
            //return 0 if we can't make a stair with this many blocks without repeating a step
            if (numBlocks > FullStair.MaxCount(maxHeight)) { return 0; }

            //known simple cases 2,1,0
            if (numBlocks <= 2) { return 1; }

            //use recursion
            long numCases = 0;
            for (int i = Math.Min(numBlocks, maxHeight); i > 0; i--)
            {
                //next stair column attempts i blocks
                long partial = CountRecursiveOriginal(numBlocks - i, i - 1);

                //if we have too many blocks for MaxHeight, then stop attempting any more
                if (partial == 0) break;

                numCases += partial;
            }
            return numCases;
        }

        private static long CountRecursive(int numBlocks, int maxHeight)
        {
            //return 0 if we can't make a stair with this many blocks without repeating a step
            if (numBlocks > FullStair.MaxCount(maxHeight)) { return 0; }

            //known simple cases 2,1,0
            if (numBlocks <= 2) { return 1; }

            //use recursion
            long numCases = 0;
            for(int i=Math.Min(numBlocks, maxHeight); i > 0; i--)
            {
                //next stair column attempts i blocks
                long partial = StairCountLookup(numBlocks - i, i - 1);

                //if we have too many blocks for MaxHeight, then stop attempting any more
                if (partial == 0) break;

                numCases += partial;
            }
            return numCases;
        }

        private static long StairCountLookup(int numBlocks, int maxHeight)
        {
            //lookup already calculated partial results
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
            long partial = CountRecursive(numBlocks, maxHeight);
            (dict[numBlocks]).Add(maxHeight, partial);

            return partial;
        }

    }
}
