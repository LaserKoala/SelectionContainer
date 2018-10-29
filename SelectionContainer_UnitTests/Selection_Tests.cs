using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_6_SelectionContainer;
using System.Linq;

namespace SelectionContainer_UnitTests
{
    [TestClass]
    public class Selection_Tests
    {
        [TestMethod]
        public void EqualSequence_Test1()
        {
            var inputArray = new int[] { 1, 2, 3, 4 };
            var expectedArray = new int[] { 2, 3, 4 };

            var skip = 1;
            var take = 3;

            var container = new Container();
            var actualArray = container.Select<int>(container.Register(inputArray), skip, take).ToList();

            Assert.AreEqual(
                true,
                Enumerable.SequenceEqual(expectedArray, actualArray)
                );
        }

        [TestMethod]
        public void EqualSequence_Test2()
        {
            var inputArray = new string[] { "Hello", "Brother", "And", "World", "my", "Coffee" };
            var expectedArray = new string[] { "Brother", "And" };

            var skip = 1;
            var take = 2;

            var container = new Container();
            var actualArray = container.Select<string>(container.Register(inputArray), skip, take).ToList();

            Assert.AreEqual(
                true,
                Enumerable.SequenceEqual(expectedArray, actualArray)
                );
        }

        [TestMethod]
        public void EqualSequence_Test3()
        {
            var inputArray = new int[] { 123, 5463, 5433443, 6335, 234324 };
            var expectedArray = new int[] { 6335, 234324 };

            var skip = 3;
            var take = 2;

            var container = new Container();
            var actualArray = container.Select<int>(container.Register(inputArray), skip, take).ToList();

            Assert.AreEqual(
                true,
                Enumerable.SequenceEqual<int>(expectedArray, actualArray)
                );
        }

       
    }
}
