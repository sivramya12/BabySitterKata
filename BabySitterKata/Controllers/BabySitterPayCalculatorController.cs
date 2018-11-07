using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabySitterKata.Models;
namespace BabySitterKata.Controllers
{
    public class BabySitterPayCalculatorController : Controller
    {
        // GET: BabySitterPayCalculator
        [HttpGet]
        public ActionResult Index()
        {
            List<string> amorpm = new List<string>();
            amorpm.Add("AM");
            amorpm.Add("PM");
            ViewBag.amorpm = new SelectList(amorpm);
            List<string> familyname = new List<string>();
            familyname.Add("A");
            familyname.Add("B");
            familyname.Add("C");
            ViewBag.familyname = new SelectList(familyname);


            ViewBag.starttimemessage = "******Please enter round time not a fractional one*******";
            return View();
        }

        [HttpPost]
        public ActionResult Index(BabySitterCalculatorModelclass bc)
        {

            List<string> amorpm = new List<string>();
            amorpm.Add("AM");
            amorpm.Add("PM");
            ViewBag.amorpm = new SelectList(amorpm);
            List<string> familyname = new List<string>();
            familyname.Add("A");
            familyname.Add("B");
            familyname.Add("C");
            ViewBag.familyname = new SelectList(familyname);
           ViewBag.starttimemessage = "******Please enter round time between 5PM to 4AM  *******";

            BabySitterPayCalculator bcalc = new BabySitterPayCalculator();
            string result = bcalc.payCalculator(bc.familyname, bc.starttime, bc.amorpmstarttime, bc.endtime, bc.amorpmendtime);
            if (result== "InvalidCredentials")
                ViewBag.result = result+"...Please enter valid credentials and try again...";
            else
            ViewBag.result = "Baby Sitters Pay is : :"+result;
            ModelState.Clear();
            return View();

           
        }
    }
}