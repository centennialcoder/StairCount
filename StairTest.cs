using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stair;
using System;

namespace TestProject
{
    [TestClass]
    public class StairTest
    {
        [TestMethod]
        public void TestMaxStair()
        {
            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine($"FullStair({i}) = {FullStair.MaxCount(i)}");
            }
            Assert.AreEqual(3, FullStair.MaxCount(2));
            Assert.AreEqual(6, FullStair.MaxCount(3));
            Assert.AreEqual(15, FullStair.MaxCount(5));
        }

        [TestMethod]
        public void TestStairCount()
        {
            Assert.AreEqual(1, StairCount.Count(3));
            Assert.AreEqual(2, StairCount.Count(5));
            Assert.AreEqual(9, StairCount.Count(10));
        }
    }
}
