using System;

namespace Stair
{
    public class Stair
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stair");

            for(int i = 3; i < 10; i++)
            {
                Console.Write($"Stair({i})=");
                Console.WriteLine(StairRecursive.Val(i));
            }

            Console.WriteLine($"Stair(200)={StairRecursive.Val(200):#,#}");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

    }
}
