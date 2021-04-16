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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid == true) 
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                
                if(a > 0)
                {
                    TempData["Message"] = "<p class=\"alert alert-success col-12\">The data was inserted</p>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "<p class=\"alert alert-danger col-12\">The data was deleted</p>";
                }   
            }
            return View();
        }
    }
}