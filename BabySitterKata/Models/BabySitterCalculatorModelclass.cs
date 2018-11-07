using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabySitterKata.Models
{
    public class BabySitterCalculatorModelclass
    {
        public float starttime { get; set; }
        public float endtime { get; set; }
        public string amorpmstarttime { get; set; }
        public string amorpmendtime { get; set; }
        public string familyname { get; set; }
        public float calculatedpay { get; set; }
    }
}