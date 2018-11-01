using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabySitterKata.Models
{
    public class BabySitterPayCalculator
    {
        public string startTimeValidate(float time,string amorpm)
        {
           
            if((time>=5.0)&&(amorpm=="PM"))
            {
                return ("valid");
            }
            else
            {
                return ("invalid");
            }
        }
    }
}