using Entity_Framework_Code_First_Approach.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

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
        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["Update"] = "<p class=\"alert alert-success col-12\">The data was updated</p>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "<p class=\"alert alert-danger col-12\">The data was not updated</p>";
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if(a > 0)
            {
                TempData["Delete"] = "<p class=\"alert alert-danger\">The data has been deleted</p>";
            }
            else
            {
                TempData["Delete"] = "<p class\"alert alert-danger\">The data was not deleted</p>";
            }
            return RedirectToAction("Index"); 
        }
        public ActionResult Details(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
    }
}