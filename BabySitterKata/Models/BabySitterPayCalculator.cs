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
            else if ((amorpmendtime == "AM") && (amorpmstarttime == "PM") && (starttime >= 5) && (endtime <= 4))
                return ("valid");
            else
                return ("invalid");
        }

        public string payCalculator(string familyname,double starttime,string amorpmstarttime,double endtime,string amorpmendtime)
        {
            double totalworkedhours=0;
            double totalpay=0;
            string payamount="invalid";

            string starttimevalidation = startTimeValidate(starttime, amorpmstarttime);
            string endtimevalidation = endTimeValidate(endtime, amorpmendtime);
            string onefamilypernightvalidation = familyValidate(familyname);
            string endtimebeforestarttimevalidation = endTimeBeforeStarttime(endtime, amorpmendtime,starttime, amorpmstarttime);

            //validating input
            if (starttimevalidation == "invalid")
                return (payamount = "InvalidStartTime");
            else if (endtimevalidation == "invalid")
                return (payamount = "InvalidEndTime");
            else if (onefamilypernightvalidation == "invalid")
                return (payamount = "InvalidFamilyName");
            else if (endtimebeforestarttimevalidation == "invalid")
                return (payamount = "InvalidStartandEndTime");
            else
            {
                if (familyname == "A")
                {
                    if ((amorpmstarttime == "PM") && (amorpmendtime == "PM"))
                    {
                        totalworkedhours = endtime - starttime;
                        if (endtime <= 11)
                        {
                            totalpay = totalworkedhours * 15;
                            payamount = "$" + totalpay;
                            return payamount;
                        }
                        else
                            return payamount;
                    }
                    else
                        return payamount;
                }
                else
                    return payamount;
            }
        }
    }
}