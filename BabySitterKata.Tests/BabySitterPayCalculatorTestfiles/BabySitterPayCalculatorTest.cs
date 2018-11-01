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
            string isStartTimeValid;
            BabySitterPayCalculator b = new BabySitterPayCalculator();
            //checking starting time exactly 5PM
            isStartTimeValid = b.startTimeValidate(5,"PM");
            Assert.AreEqual("valid", isStartTimeValid);

            //checking starting time after 5PM
            isStartTimeValid = b.startTimeValidate(6, "PM");
            Assert.AreEqual("valid", isStartTimeValid);

            //checking starting time before 5PM
            isStartTimeValid = b.startTimeValidate(4, "PM");
            Assert.AreEqual("invalid", isStartTimeValid);

            //checking for staring time as 12AM
            isStartTimeValid = b.startTimeValidate(12, "AM");
            Assert.AreEqual("valid", isStartTimeValid);

            //checking for staring time as 1AM to ensure it accepts valid AM values as well
            isStartTimeValid = b.startTimeValidate(1, "AM");
            Assert.AreEqual("valid", isStartTimeValid);

            //checking for staring time as 4AM to ensure it won't accepts invalid AM values
            isStartTimeValid = b.startTimeValidate(4, "AM");
            Assert.AreEqual("invalid", isStartTimeValid);

        }
    }
}
