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

            //checking for leaving time 12 AM
            Assert.AreEqual("valid", b.endTimeValidate(12, "AM"));

            //checking for leaving time 4 AM exact
            Assert.AreEqual("valid", b.endTimeValidate(4, "AM"));

            //checking for leaving time 5 AM
            Assert.AreEqual("invalid", b.endTimeValidate(5, "AM"));

            //checking for leaving time 11 PM
            Assert.AreEqual("valid", b.endTimeValidate(11, "PM"));

            //checking for leaving time 5 PM
            Assert.AreEqual("invalid", b.endTimeValidate(5, "PM"));

        }

        [TestMethod]
        public void onlyOneFamilyPerNightCheck()
        {
            //checking for family A  
            Assert.AreEqual("valid", b.familyvalidate("A"));
            //checking for family B
            Assert.AreEqual("valid", b.familyvalidate("B"));
            //checking for family C
            Assert.AreEqual("valid", b.familyvalidate("C"));
            //checking for family A and B
            Assert.AreEqual("invalid", b.familyvalidate("AB"));
            //checking for family B and C
            Assert.AreEqual("invalid", b.familyvalidate("BandC"));
            //checking for family A and C
            Assert.AreEqual("invalid", b.familyvalidate("A&C"));
            //checking for family A, B and C
            Assert.AreEqual("invalid", b.familyvalidate("A&CandB"));
        }


        }
}
