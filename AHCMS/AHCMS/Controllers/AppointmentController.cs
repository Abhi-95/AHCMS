using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHCMS.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult ViewDoctor()
        {
            return View();
        }

        public ActionResult DoctorProfile()
        {
            return View();
        }

        public ActionResult BookAppointment()
        {
            return View();
        }


        public ActionResult Calender()
        {
            //long str = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); //1535696661477 
            //long str2 = 1535693660591;
            //long difMili = str - str2; //3000886 
            //System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            //dateTime = dateTime.AddMilliseconds(str).ToLocalTime(); //31-08-2018 11:54:21 
            //ViewBag.utc = str;
            //ViewBag.Local = dateTime; 

            //ViewBag.DiffMili = difMili;
            //System.DateTime dateTime2 = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            //dateTime2 = dateTime2.AddMilliseconds(difMili);
            //ViewBag.Diff = dateTime2.Minute; // 51

            return View();
        }
    }
}