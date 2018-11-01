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
           //start time no later than 5PM
            if((starttime>=5.0)&&(amorpm=="PM"))           
            return ("valid");
            else
            {
                //AM validation
                if ((starttime == 12) && (amorpm == "AM"))
                    return ("valid");
                else if ((starttime >= 1.0) && (starttime < 4.0) && (amorpm == "AM"))                
                    return ("valid");               
                else
                    return ("invalid");
            }
        }

        public string endTimeValidate(float endTime, string amorpm)
        {
            if ((endTime <= 4) && (amorpm == "AM"))
                return ("valid");
            else
                return ("invalid");
        }

    }
}