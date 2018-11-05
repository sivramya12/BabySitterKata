using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabySitterKata.Models
{
    public class BabySitterPayCalculator
    {
        public string startTimeValidate(double starttime,string amorpm)
        {
            if ((int)starttime == starttime)
            {
                if ((starttime >= 5.0) && (amorpm == "PM"))
                    return ("valid");
                else if ((starttime == 12.0) && (amorpm == "AM"))
                    return ("valid");
                else if ((starttime >= 1.0) && (starttime < 4.0) && (amorpm == "AM"))
                    return ("valid");
                else
                    return ("invalid");
            }
            else
                return ("invalid");
        }

        public string endTimeValidate(double endTime, string amorpm)
        {
            if ((int)endTime == endTime)
            {
                if ((endTime == 12.0) && (amorpm == "AM"))
                    return ("valid");
                else if ((endTime <= 4.0) && (amorpm == "AM"))
                    return ("valid");
                else if ((endTime > 5.0) && (amorpm == "PM"))
                    return ("valid");
                else
                    return ("invalid");
            }
            else
                return ("invalid");
          
        }

        public string familyValidate(string familyname)
        {
            if ((familyname == "A")||(familyname=="B")||(familyname=="C"))
                return ("valid");
            else
                return ("invalid");
        }

        public string endTimeBeforeStarttime(double endtime,string amorpmendtime, double starttime, string amorpmstarttime)
        {
            if ((amorpmendtime == "PM") && (amorpmstarttime == "PM") && (starttime >= 5))
            {
                if (endtime > starttime)
                    return ("valid");
                else
                    return ("invalid");
            }
            else if ((amorpmendtime == "AM") && (amorpmstarttime == "AM"))
            {
                //both starttime and endtime are not equal
                if (endtime == 12)
                    return ("invalid");
                else if ((starttime == 12) && (endtime <= 4))
                    return ("valid");
                else if ((endtime > starttime) && endtime <= 4)
                    return ("valid");
                else
                    return ("invalid");
            }
            else if ((amorpmendtime == "PM") && (amorpmstarttime == "AM"))
                return ("invalid");
            else if ((amorpmendtime == "AM") && (amorpmstarttime == "PM") && (starttime >= 5) && ((endtime <= 4)||(endtime==12)))
                return ("valid");
            else
                return ("invalid");
        }

        public string payCalculator(string familyname,double starttime,string amorpmstarttime,double endtime,string amorpmendtime)
        {
            string payamount= "InvalidCredentials";
            string starttimevalidation = startTimeValidate(starttime, amorpmstarttime);
            string endtimevalidation = endTimeValidate(endtime, amorpmendtime);
            string onefamilypernightvalidation = familyValidate(familyname);
            string endtimebeforestarttimevalidation = endTimeBeforeStarttime(endtime, amorpmendtime,starttime, amorpmstarttime);

            //validating input
            if ((starttimevalidation == "invalid")||endtimevalidation=="invalid"||onefamilypernightvalidation=="invalid"||endtimebeforestarttimevalidation=="invalid")
            {
                return ("InvalidCredentials");
            }
            else
            {
                if (familyname == "A")
                {
                    payamount = AFamilyPayCalculate(starttime, amorpmstarttime, endtime, amorpmendtime);
                    return payamount;
                }
                else if (familyname == "B")
                {
                    payamount = BFamilyPayCalculate(starttime, amorpmstarttime, endtime, amorpmendtime);
                    return payamount;
                }
                else if (familyname == "C")
                {
                    payamount = CFamilyPayCalculate(starttime, amorpmstarttime, endtime, amorpmendtime);
                    return payamount;
                }
                else
                    return payamount;
             }


        }

        public string AFamilyPayCalculate(double starttime, string amorpmstarttime, double endtime, string amorpmendtime)
        {
            double hoursworkedbefore11;
            double hoursworkedafter11;
            double totalpay = 0;
            string payamount="InvalidCredentials";
            if ((amorpmstarttime == "PM") && (amorpmendtime == "PM"))
            {
                hoursworkedbefore11 = endtime - starttime;
                hoursworkedafter11 = 0;
               
            }
            else if (((amorpmstarttime == "AM") && (amorpmendtime == "AM")))
            {
                if (starttime == 12)
                    hoursworkedafter11 = endtime;
                else
                    hoursworkedafter11 = endtime - starttime;
                hoursworkedbefore11 = 0;
                
            }
            else if (((amorpmstarttime == "PM") && (amorpmendtime == "AM")))
            {
                
                if (starttime == 11)
                    hoursworkedbefore11 = 0;
                else
                    hoursworkedbefore11 = 11 - starttime;
                if (endtime == 12)
                    hoursworkedafter11 = 1;
                else
                    hoursworkedafter11 = 1 + endtime;
              
            }
            else
            {
                //invalid input 
                hoursworkedbefore11 = 0;
                hoursworkedafter11 = 0;
            }
            totalpay = (hoursworkedbefore11 * 15) + (hoursworkedafter11 * 20);
            if(totalpay>0)
            payamount = "$" + totalpay;
            else
            payamount = "InvalidCredentials";
            return payamount;
           
        }

        public string BFamilyPayCalculate(double starttime, string amorpmstarttime, double endtime, string amorpmendtime)
        {
        //Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
            double totalworkedhoursbefore10 =0;
            double totalworkedhoursfrom10to12=0;
            double totalworkedhoursafter12 = 0;
            double totalpay = 0;
            string payamount = "InvalidCredentials";
            if ((amorpmstarttime == "AM") && (amorpmendtime == "AM"))
            {
                if (starttime == 12)
                    totalworkedhoursafter12 = endtime;
                else
                    totalworkedhoursafter12 = endtime - starttime;
                totalworkedhoursbefore10 = 0;
                totalworkedhoursfrom10to12 = 0;
                
            }
            else if((amorpmstarttime == "PM") && (amorpmendtime == "PM"))
            {
                if((starttime<10)&&(endtime<=10))
                {
                    totalworkedhoursbefore10 = endtime - starttime;
                    totalworkedhoursfrom10to12 = 0;
                }
                else if((starttime<10)&&(endtime>10))
                {
                    totalworkedhoursbefore10 = 10 - starttime;
                    totalworkedhoursfrom10to12 = 1;
                    //endtime-10 which will be 1 always because only possible endtime is 11 PM

                }
                else
                {
                    //starttime>=10 and endtime>10
                    totalworkedhoursbefore10 = 0;
                    totalworkedhoursfrom10to12 = 1;
                    //endtime-10 which will be 1 always because only possible endtime is 11 PM
                }
                totalworkedhoursafter12 = 0;
                
            }

            else if ((amorpmstarttime == "PM") && (amorpmendtime == "AM"))
            {
                if(starttime<10)
                {
                    totalworkedhoursbefore10 = 10 - starttime;                 
                    totalworkedhoursfrom10to12 = 2;
                    if (endtime == 12)
                        totalworkedhoursafter12 = 0;
                    else
                        totalworkedhoursafter12 = endtime;
                }
                else 
                {
                    //starttime between 10 and 12
                    totalworkedhoursbefore10 = 0;
                    if (starttime == 10)
                        totalworkedhoursfrom10to12 = 2;
                    else
                        totalworkedhoursfrom10to12 = 1;
                    if (endtime == 12)
                        totalworkedhoursafter12 = 0;
                    else
                        totalworkedhoursafter12 = endtime;

                }
                
            }
            else
            {
                totalworkedhoursbefore10 = 0;
                totalworkedhoursfrom10to12 = 0;
                totalworkedhoursafter12 = 0;

            }
            totalpay = (totalworkedhoursbefore10 * 12) + (totalworkedhoursfrom10to12 * 8) + (totalworkedhoursafter12 * 16);
            if(totalpay>0)
            payamount = "$" + totalpay;
            else
            payamount = "InvalidCredentials";
            return payamount;

          
        }


        public string CFamilyPayCalculate(double starttime, string amorpmstarttime, double endtime, string amorpmendtime)
        {
            //Family C pays $21 per hour before 9pm, then $15 the rest of the night
            double hoursworkedbefore9 =0;
            double hoursworkedafter9=0;
            double totalpay = 0;
            string payamount = "InvalidCredentials";
            if ((amorpmstarttime == "AM") && (amorpmendtime == "AM"))
            {
                hoursworkedbefore9 = 0;
                hoursworkedafter9 = endtime;
            }
            else
            {
                hoursworkedbefore9 = 0;
                hoursworkedafter9 = 0;
            }
            totalpay = (hoursworkedbefore9 * 21) + (hoursworkedafter9 * 15);
            if (totalpay > 0)
                payamount = "$" + totalpay;
            else
                payamount = "InvalidCredentials";
            return payamount;
        }

        
    }
}