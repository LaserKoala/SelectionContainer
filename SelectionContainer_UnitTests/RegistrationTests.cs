using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using SelectionContainer;

namespace SelectionContainer_UnitTests
{
    [TestClass]
    public class RegistrationTests
    {
        [TestMethod]
        public void RegisterCollectionTest()
        {
            var container = new Container();
            var list = new List<int>();

            var notExpected = Guid.Empty;
            var actual = container.Register(list);

            Assert.AreNotEqual(notExpected, actual);
        }

        [TestMethod]
        public void RegisterNullCollectionTest()
        {
            var container = new Container();
           
            Assert.ThrowsException<ArgumentNullException> (()=> container.Register(null));
        }

    }
}
