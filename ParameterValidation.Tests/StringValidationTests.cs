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
    public class StringValidationTests
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
        public void TestNullString()
        {
            String testString = null;
            Check.IsNotNull(() => testString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullStringAsWhiteSpace()
        {
            String testString = null;
            Check.IsNotNullOrWhiteSpace(() => testString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWhiteSpaceStringAsWhiteSpace()
        {
            String testString = " ";
            Check.IsNotNullOrWhiteSpace(() => testString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyStringAsWhiteSpace()
        {
            String testString = String.Empty;
            Check.IsNotNullOrWhiteSpace(() => testString);
        }

        [TestMethod]
        public void TestValidStringAsWhiteSpace()
        {
            String testString = "Valid";
            Check.IsNotNullOrWhiteSpace(() => testString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullStringAsEmpty()
        {
            String testString = null;
            Check.IsNotNullOrEmpty(() => testString);
        }

        [TestMethod]
        public void TestWhiteSpaceStringAsEmpty()
        {
            String testString = " ";
            Check.IsNotNullOrEmpty(() => testString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyStringAsEmpty()
        {
            String testString = String.Empty;
            Check.IsNotNullOrEmpty(() => testString);
        }

        [TestMethod]
        public void TestValidStringAsEmpty()
        {
            String testString = "Valid";
            Check.IsNotNullOrEmpty(() => testString);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestConstantString()
        {
            const String testConstantString = "ValidConstantString";
            Check.IsNotNull(() => testConstantString);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestLiteralString()
        {
            Check.IsNotNull(() => "Invalid");
        }
    }
}
