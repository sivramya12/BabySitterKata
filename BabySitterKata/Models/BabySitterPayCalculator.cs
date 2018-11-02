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
    }
}