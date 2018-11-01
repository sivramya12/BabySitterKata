using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabySitterKata.Models;
namespace BabySitterKata.Tests.BabySitterPayCalculatorTestfiles
{
    [TestClass]
    public class BabySitterPayCalculatorTest
    {
        BabySitterPayCalculator b = new BabySitterPayCalculator();
        [TestMethod]
        public void startsNoEarlierThan5PM()
        {
            //checking starting time exactly 5PM         
            Assert.AreEqual("valid", b.startTimeValidate(5, "PM"));

            //checking starting time after 5PM
            Assert.AreEqual("valid", b.startTimeValidate(6, "PM"));

            //checking starting time before 5PM           
            Assert.AreEqual("invalid", b.startTimeValidate(4, "PM"));

            //checking for staring time as 12AM
            Assert.AreEqual("valid",b.startTimeValidate(12, "AM"));

            //checking for staring time as 1AM to ensure it accepts valid AM values as well
            Assert.AreEqual("valid", b.startTimeValidate(1, "AM"));

            //checking for staring time as 4AM to ensure it won't accepts invalid AM values         
            Assert.AreEqual("invalid", b.startTimeValidate(4, "AM"));

        }

        [TestMethod]
        public void leavesNoLaterThan4AM()
        {
            //checking for leaving time 3 AM
            Assert.AreEqual("valid", b.endTimeValidate(3, "AM"));

        }



        }
}
