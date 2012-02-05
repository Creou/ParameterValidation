using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssertRouting;
using ParameterValidation;

namespace ParameterValidation.Tests
{
    [TestClass]
    public class GuidValidationTests
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
        [ExpectedException(typeof(ArgumentException))]
        public void TestBlankGuidString()
        {
            String testGuid = "";
            var data = Check.IsValidGuid(() => testGuid);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullGuidString()
        {
            String testGuid = null;
            var data = Check.IsValidGuid(() => testGuid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidGuidString()
        {
            String testGuid = "Invalid";
            var data = Check.IsValidGuid(() => testGuid);
        }

        [TestMethod]
        public void TestValidGuidStringAsValid()
        {
            String testGuid = "4244F17F-FA60-4FDD-AF3E-2D03D5FE8091";
            var data = Check.IsValidGuid(() => testGuid);
            Assert.IsTrue(data == new Guid(testGuid), "Returned guid should match test data.");
        }

        [TestMethod]
        public void TestValidGuidStringAsNonEmpty()
        {
            String testGuid = "4244F17F-FA60-4FDD-AF3E-2D03D5FE8091";
            var data = Check.IsValidNotEmptyGuid(() => testGuid);
            Assert.IsTrue(data == new Guid (testGuid), "Returned guid should match test data.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestZeroGuidStringAsNonEmpty()
        {
            String testGuid = "00000000-0000-0000-0000-000000000000";
            var data = Check.IsValidNotEmptyGuid(() => testGuid);
        }

        [TestMethod]
        public void TestZeroGuidStringAsValid()
        {
            String testGuid = "00000000-0000-0000-0000-000000000000";
            var data = Check.IsValidGuid(() => testGuid);
            Assert.IsTrue(data == Guid.Empty, "Returned guid should be empty.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyGuidAsNotEmpty()
        {
            Guid testGuid = Guid.Empty;
            Check.IsNotEmpty(() => testGuid);
        }

        [TestMethod]
        public void TestValidGuidAsNotEmpty()
        {
            Guid testGuid = new Guid ("4244F17F-FA60-4FDD-AF3E-2D03D5FE8091");
            Check.IsNotEmpty(() => testGuid);
        }
    }
}
