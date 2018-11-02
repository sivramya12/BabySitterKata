using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabySitterKata.Models
{
    public class BabySitterPayCalculator
    {
        public string startTimeValidate(float starttime,string amorpm)
        {
            if((starttime>=5.0)&&(amorpm=="PM"))           
                    return ("valid");
            else if ((starttime == 12.0) && (amorpm == "AM"))
                    return ("valid");
            else if ((starttime >= 1.0) && (starttime < 4.0) && (amorpm == "AM"))                
                    return ("valid");               
             else
                    return ("invalid");
            
        }

        public string endTimeValidate(float endTime, string amorpm)
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

        public string familyvalidate(string familyname)
        {
            if (familyname == "A")
                return ("valid");
            else
                return ("invalid");
        }
    }
}