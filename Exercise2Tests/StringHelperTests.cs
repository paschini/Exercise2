using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2.Tests
{
    [TestClass()]
    public class StringHelperTests
    {
        [TestMethod()]
        public void RepeatedInputTest()
        {
            string input = "Test";
            string expectedOutput = "1. Test, 2. Test, 3. Test, 4. Test, 5. Test, 6. Test, 7. Test, 8. Test, 9. Test, 10. Test.";

            string actualOutput = StringHelper.RepeatedInput(input);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod()]
        public void SplitBySpacesTest()
        {
            string input = "  This is   a test string  ";
            string[] expectedOutput = { "This", "is", "a", "test", "string" };

            string[] actualOutput = StringHelper.SplitBySpaces(input);
            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod()]
        public void Get3rdWordTest()
        {
            string input = "  This is   a test string  ";
            string expectedOutput = "a";

            string? actualOutput = StringHelper.Get3rdWord(input);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod()]
        public void Get3rdWordTest_InsufficientWords_ReturnsNull()
        {
            string input = "Too short";

            string? actualOutput = StringHelper.Get3rdWord(input);
            Assert.IsNull(actualOutput);
        }
    }
}