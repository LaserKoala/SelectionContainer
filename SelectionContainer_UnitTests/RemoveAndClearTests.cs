using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelectionContainer;
using System;
using System.Collections.Generic;

namespace SelectionContainer_UnitTests
{
    [TestClass]
    public class RemoveAndClearTests
    {
        [TestMethod]
        public void ClearContainer()
        {
            var container = new Container();

            for (var iter = 0; iter < 5; iter++)
            {
                container.Register(new List<object>());
            }
            container.Clear();

            Assert.AreEqual(
                0,
                container.Count);
        }

        [TestMethod]
        public void RemoveElement()
        {
            var container = new Container();
            var id = container.Register(new List<string>());

            Assert.IsTrue(container.Remove(id));
            Assert.AreEqual(
                0,
                container.Count);
        }

        [TestMethod]
        public void TryRemoveNonexistElement()
        {
            var container = new Container();
            container.Register(new List<string>());

            var id = Guid.NewGuid();

            Assert.IsFalse(container.Remove(id));
            Assert.AreEqual(
                1,
                container.Count);
        }
    }
}
