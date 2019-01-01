
using System;
using System.Collections.Generic;
namespace Stair
{
    public static class FullStair
    {
        const int MAXN = 200;
        private static Dictionary<int, int> _lookup = new Dictionary<int, int>();

        static FullStair()
        {
            int currentTotal = 0;
            for (int i = 0; i <= MAXN; i++)
            {
                currentTotal += i;
                _lookup.Add(i, currentTotal);
            }
        }

        public static int MaxCount(int height)
        {
            if (_lookup.ContainsKey(height))
            {
                return _lookup[height];
            }
            throw new ArgumentException($"height {height} out of range");
        }

    }
}
