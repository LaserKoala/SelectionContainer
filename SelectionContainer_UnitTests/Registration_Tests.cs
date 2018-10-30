using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_6_SelectionContainer;

namespace SelectionContainer_UnitTests
{
    [TestClass]
    public class Registration_Tests
    {
        [TestMethod]
        public void RegisterArray_Test()
        {
            var container = new Container();
            var array = new int[5];

            var notExpected = Guid.Empty;
            var actual = container.Register(array);

            Assert.AreNotEqual(notExpected, actual);
        }


        [TestMethod]
        public void RegisterList_Test()
        {
            var container = new Container();
            var list = new List<int>();

            var notExpected = Guid.Empty;
            var actual = container.Register(list);

            Assert.AreNotEqual(notExpected, actual);
        }


        [TestMethod]
        public void RegisterStack_Test()
        {
            var container = new Container();
            var stack = new Stack<int>();

            var notExpected = Guid.Empty;
            var actual = container.Register(stack);

            Assert.AreNotEqual(notExpected, actual);
        }


        [TestMethod]
        public void RegisterQueue_Test()
        {
            var container = new Container();
            var queue = new Queue<int>();

            var notExpected = Guid.Empty;
            var actual = container.Register(queue);

            Assert.AreNotEqual(notExpected, actual);
        }


        [TestMethod]
        public void RegisterDictonary_Test()
        {
            var container = new Container();
            var dictonary = new Dictionary<int, int>();

            var notExpected = Guid.Empty;
            var actual = container.Register(dictonary);

            Assert.AreNotEqual(notExpected, actual);
        }


        [TestMethod]
        public void NullElement_FailTest()
        {
            var container = new Container();
            List<int> nullList = null;

            Assert.ThrowsException<ArgumentNullException>(() => container.Register(null));
            Assert.ThrowsException<ArgumentNullException>(() => container.Register(nullList));
        }
    }
}
