using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParameterValidation;
using AssertRouting;

namespace ParameterValidation.Tests
{
    [TestClass]
    public class ObjectValidationTests
    {
        private static AssertRouter _assertRouter;

        [ClassInitialize()]
        public static void Initialise(TestContext context)
        {
            _assertRouter = new AssertRouter(true, false);
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            _assertRouter.Restore();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestObjectNull()
        {
            Object testObject = null;
            Check.IsNotNull(() => testObject);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestNullExpression()
        {
            Check.IsNotNull(() => null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestNewExpression()
        {
            Check.IsNotNull(() => new Object());
        }
    }
}
