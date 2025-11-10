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
    public class MoviesPriceTests
    {
        [TestMethod()]
        public void CalculatePersonPriceTest()
        {
            var testCases = new[]
            {
                new { Age = 4, ExpectedPrice = 0.0, ExpectedMessage = "Barn under 5 år tittar grattis på Bio: " },
                new { Age = 10, ExpectedPrice = 80.0, ExpectedMessage = "Personen är berättigad till ungdomspris: " },
                new { Age = 20, ExpectedPrice = 120.0, ExpectedMessage = "Personen är berättigad till standardpris: " },
                new { Age = 63, ExpectedPrice = 120.0, ExpectedMessage = "Personen är berättigad till standardpris: " },
                new { Age = 65, ExpectedPrice = 90.0, ExpectedMessage = "Personen är berättigad till pensionärspris: " },
                new { Age = 101, ExpectedPrice = 0.0, ExpectedMessage = "Personen är över 100 år! Tittar grattis på Bio: " },
            };

            foreach (var testCase in testCases)
            {
                var result = MoviesPrice.CalculatePersonPrice(testCase.Age);
                Assert.AreEqual(testCase.ExpectedPrice, result.Price, $"Failed for Age: {testCase.Age}");
                StringAssert.StartsWith(result.Message, testCase.ExpectedMessage, $"Failed for Age: {testCase.Age}");
            }
        }
    }
}