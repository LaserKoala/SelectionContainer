using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelectionContainer;
using System.Linq;
using System.Collections.Generic;

namespace SelectionContainer_UnitTests
{
    [TestClass]
    public class SelectionTests
    {
        [TestMethod]
        public void EqualSequenceTest1()
        {
            var inputSequence = new int[] { 1, 2, 3, 4 };
            var expectedSequence = new int[] { 2, 3, 4 };
            var container = new Container();

            var id = container.Register(inputSequence);
            var skip = 1;
            var take = 3;
            
            var actualSequence = container.Select<int>(id, skip, take);

            Assert.AreEqual(
                true,
                Enumerable.SequenceEqual(expectedSequence, actualSequence)
                );
        }


        [TestMethod]
        public void EqualSequenceTest2()
        {
            var inputSequence = new string[] { "Hello", "Brother", "And", "World", "my", "Coffee" };
            var expectedSequence = new string[] { "Brother", "And" };
            var container = new Container();

            var id = container.Register(inputSequence);
            var skip = 1;
            var take = 2;

            var actualSequence = container.Select<string>(id, skip, take);

            Assert.AreEqual(
                true,
                Enumerable.SequenceEqual(expectedSequence, actualSequence)
                );
        }


        [TestMethod]
        public void DifferentGenericTypeTest1()
        {
            var inputSequence = new int[] { 1, 2, 3, 4 };
            var container = new Container();

            var id = container.Register(inputSequence);
            var skip = 1;
            var take = 3;

            var actualSequence = container.Select<String>(id, skip, take);

            Assert.IsInstanceOfType(
                actualSequence, 
                typeof(IEnumerable<String>));
        }


        [TestMethod]
        public void DifferentGenericTypeTest2()
        {
            var inputSequence = new int[] { 1, 2, 3, 4 };
            var container = new Container();

            var id = container.Register(inputSequence);
            var skip = 1;
            var take = 3;

            var actualSequence = container.Select<Boolean>(id, skip, take);

            Assert.IsInstanceOfType(
                actualSequence,
                typeof(IEnumerable<Boolean>));
        }
    }
}