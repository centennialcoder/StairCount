using System;
using System.Collections.Generic;
using System.Text;

namespace Stair
{
    public static class MaxStair
    {
        const int MAXN = 200;
        private static Dictionary<int, int> _lookup = new Dictionary<int, int>();

        static MaxStair()
        {
            int currentTotal = 0;
            for (int i = 0; i <= MAXN; i++)
            {
                currentTotal += i;
                _lookup.Add(i, currentTotal);
            }
        }

        public static int Max(int height)
        {
            if (_lookup.ContainsKey(height))
            {
                return _lookup[height];
            }
            throw new ArgumentException($"height {height} out of range");
        }

    }
}
