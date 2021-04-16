using Entity_Framework_Code_First_Approach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entity_Framework_Code_First_Approach.Controllers
{
    public class StudentsController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Students
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
    }
}