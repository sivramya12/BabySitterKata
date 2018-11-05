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

            //cheking for full fraction starttime
            Assert.AreEqual("invalid", b.startTimeValidate(6.5, "PM"));

            //cheking for full fraction starttime
            Assert.AreEqual("invalid", b.startTimeValidate(37.0/5.0, "PM"));
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

            //cheking for full fraction leavetime
            Assert.AreEqual("invalid", b.endTimeValidate(1.5, "AM"));

            //cheking for full fraction leavetime
            Assert.AreEqual("invalid", b.endTimeValidate(37.0 / 5.0, "PM"));


        }

        [TestMethod]
        public void onlyOneFamilyPerNightCheck()
        {
            //checking for family A  
            Assert.AreEqual("valid", b.familyValidate("A"));

            //checking for family B
            Assert.AreEqual("valid", b.familyValidate("B"));

            //checking for family C
            Assert.AreEqual("valid", b.familyValidate("C"));

            //checking for family A and B
            Assert.AreEqual("invalid", b.familyValidate("AB"));

            //checking for family B and C
            Assert.AreEqual("invalid", b.familyValidate("BandC"));

            //checking for family A and C
            Assert.AreEqual("invalid", b.familyValidate("A&C"));

            //checking for family A, B and C
            Assert.AreEqual("invalid", b.familyValidate("A&CandB"));
        }
        [TestMethod]
        public void endTimeBeforeStartTimeValidate()
        {
            //checking for endtime in PM and starttime in PM
            Assert.AreEqual("invalid", b.endTimeBeforeStarttime(6,"PM",8,"PM"));

            //checking for endtime PM and starttime PM
            Assert.AreEqual("valid", b.endTimeBeforeStarttime(8, "PM", 6, "PM"));

            //checking for endtime PM and starttime PM
            Assert.AreEqual("invalid", b.endTimeBeforeStarttime(7, "PM", 12, "PM"));

            //checking out of range value both PM
            Assert.AreEqual("invalid", b.endTimeBeforeStarttime(3, "PM", 2, "PM"));

            //checking for endtime AM and starttime AM
            Assert.AreEqual("invalid", b.endTimeBeforeStarttime(12, "AM", 2, "AM"));

            //checking for endtime AM and starttime AM
            Assert.AreEqual("valid", b.endTimeBeforeStarttime(2, "AM", 12, "AM"));

            //checking for endtime AM and starttime AM
            Assert.AreEqual("invalid", b.endTimeBeforeStarttime(2, "AM", 3, "AM"));

            //checking out of range endtime AM and starttime AM
            Assert.AreEqual("invalid", b.endTimeBeforeStarttime(5, "AM", 3, "AM"));

            //checking out of range endtime AM and starttime AM
            Assert.AreEqual("invalid", b.endTimeBeforeStarttime(4, "AM", 6, "AM"));

            //checking for endtime PM and starttime AM
            Assert.AreEqual("invalid", b.endTimeBeforeStarttime(4, "PM", 6, "AM"));

            //checking for endtime AM and starttime PM
            Assert.AreEqual("valid", b.endTimeBeforeStarttime(4, "AM", 6, "PM"));

            //checking for endtime AM and starttime PM
            Assert.AreEqual("invalid", b.endTimeBeforeStarttime(5, "AM", 6, "PM"));

            //checking for endtime AM and starttime PM
            Assert.AreEqual("invalid", b.endTimeBeforeStarttime(3, "AM", 3, "PM"));

            //checking for endtime AM and starttime PM
            Assert.AreEqual("valid", b.endTimeBeforeStarttime( 12, "AM", 11, "PM"));

           
        }

        [TestMethod]
        public void payCalculatorValidate()
        {
            //pay calculation invalid input
            Assert.AreEqual("InvalidCredentials", b.payCalculator("A",3, "PM", 10, "PM"));

            //pay calculation invalid input
            Assert.AreEqual("InvalidCredentials", b.payCalculator("A", 6, "PM", 5, "AM"));

            //pay calculation invalid input
            Assert.AreEqual("InvalidCredentials", b.payCalculator("AandB", 6, "PM", 3, "AM"));

            //pay calculation invalid input
            Assert.AreEqual("InvalidCredentials", b.payCalculator("A", 6, "PM", 6, "PM"));

            //pay calculation invalid input
            Assert.AreEqual("InvalidCredentials", b.payCalculator("AandB", 2, "PM", 5, "AM"));

            //pay calculation for family A with both starts and ends in PM
            Assert.AreEqual("$30", b.payCalculator("A", 6, "PM", 8, "PM"));

            //pay calculation for family A with both starts and ends in AM
            Assert.AreEqual("$60", b.payCalculator("A", 1, "AM", 4, "AM"));

            //pay calculation for family A with both starts and ends in AM
            Assert.AreEqual("$80", b.payCalculator("A", 12, "AM", 4, "AM"));

            //pay calculation for family A starts in PM and ends in AM
            Assert.AreEqual("$90", b.payCalculator("A",9, "PM", 2, "AM"));

            //pay calculation for family A starts in PM and ends in AM
            Assert.AreEqual("$60", b.payCalculator("A", 11, "PM", 2, "AM"));

            //pay calculation for family A starts in PM and ends in AM
            Assert.AreEqual("$20", b.payCalculator("A", 11, "PM", 12, "AM"));

            //pay calculation for family A starts in PM and ends in AM
            Assert.AreEqual("$190", b.payCalculator("A", 5, "PM", 4, "AM"));

            //pay calculation for family B with both starts and ends in AM
            Assert.AreEqual("$32", b.payCalculator("B", 1, "AM", 3, "AM"));

            //pay calculation for family B with both starts and ends in PM
            Assert.AreEqual("$20", b.payCalculator("B",9, "PM", 11, "PM"));

            //pay calculation for family B with both starts and ends in PM
            Assert.AreEqual("$48", b.payCalculator("B", 5, "PM", 9, "PM"));

            //pay calculation for family B with both starts and ends in PM
            Assert.AreEqual("$60", b.payCalculator("B", 5, "PM", 10, "PM"));

            //pay calculation for family B with both starts and ends in PM
            Assert.AreEqual("$8", b.payCalculator("B", 10, "PM", 11, "PM"));

            //pay calculation for family B  work starts in PM and ends in AM
            Assert.AreEqual("$60", b.payCalculator("B", 9, "PM", 2, "AM"));

            //pay calculation for family B  work starts in PM and ends in AM
            Assert.AreEqual("$8", b.payCalculator("B", 11, "PM", 12, "AM"));

            //pay calculation for family B  work starts in PM and ends in AM
            Assert.AreEqual("$48", b.payCalculator("B", 10, "PM", 2, "AM"));

            //pay calculation for family B  work starts in PM and ends in AM
            Assert.AreEqual("$140", b.payCalculator("B", 5, "PM", 4, "AM"));

        }

    }
}
