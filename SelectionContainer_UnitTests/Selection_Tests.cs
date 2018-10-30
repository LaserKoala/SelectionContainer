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
            var container = new Container();

            var id = container.Register(inputArray);
            var skip = 1;
            var take = 3;
            
            var actualArray = container.Select<int>(id, skip, take).ToList();

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
            var container = new Container();

            var id = container.Register(inputArray);
            var skip = 1;
            var take = 2;

            var actualArray = container.Select<string>(id, skip, take).ToList();

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
            var container = new Container();

            var id = container.Register(inputArray);
            var skip = 3;
            var take = 2;

            var actualArray = container.Select<int>(id, skip, take).ToList();

            Assert.AreEqual(
                true,
                Enumerable.SequenceEqual<int>(expectedArray, actualArray)
                );
        }


        [TestMethod]
        public void IncorrectGenericType_FailTest()
        {
            var inputArray = new int[] { 123, 5463, 5433443, 6335, 234324 };
            var container = new Container();

            var id = container.Register(inputArray);
            var skip = 1;
            var take = 1;
            
            Assert.ThrowsException<InvalidCastException>(()=> container.Select<string>(id, skip, take));
        }


        [TestMethod]
        public void IncorrectSkip_FailTest()
        {
            var inputArray = new int[] { 123, 5463, 5433443, 6335, 234324 };
            var container = new Container();

            var id = container.Register(inputArray);
            var skip = -5;
            var take = 1;
            
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => container.Select<int>(id, skip, take));
        }


        [TestMethod]
        public void IncorrectTake_FailTest()
        {
            var inputArray = new int[] { 123, 5463, 5433443, 6335, 234324 };
            var container = new Container();

            var id = container.Register(inputArray);
            var skip = 0;
            var take = 0;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => container.Select<int>(id, skip, take));
        }


        [TestMethod]
        public void NonRegisteredID_FailTest()
        {
            var inputArray = new int[] { 123, 5463, 5433443, 6335, 234324 };
            var container = new Container();

            var id = Guid.NewGuid();
            var skip = 1;
            var take = 2;

            Assert.ThrowsException<ArgumentException>(() => container.Select<int>(id, skip, take));
        }


        [TestMethod]
        public void EmptyID_FailTest()
        {
            var inputArray = new int[] { 123, 5463, 5433443, 6335, 234324 };
            var container = new Container();

            var id = Guid.Empty;
            var skip = 1;
            var take = 2;

            Assert.ThrowsException<ArgumentNullException>(() => container.Select<int>(id, skip, take));
        }
    }
}
