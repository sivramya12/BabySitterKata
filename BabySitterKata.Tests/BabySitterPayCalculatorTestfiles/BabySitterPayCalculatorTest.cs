using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabySitterKata.Models;
namespace BabySitterKata.Tests.BabySitterPayCalculatorTestfiles
{
    [TestClass]
    public class BabySitterPayCalculatorTest
    {
        [TestMethod]
        public void startsNoEarlierThan5PM()
        {
            BabySitterPayCalculator b = new BabySitterPayCalculator();
            //checking starting time exactly 5PM
            string isStarttimeValid = b.startTimeValidate(5,"PM");
            Assert.AreEqual("valid", isStarttimeValid);
        }
    }
}
