using Asp.net.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net.Controllers
{
    public class CoursesController : Controller
    {
        ApplictaionDbContext DbContext = new ApplictaionDbContext();
        public IActionResult Index()
        {
            List<Course> Courses = DbContext.Courses.ToList();
            return View(Courses);
        }

        public IActionResult CheckDegree(int Degree)
        {
            if(Degree <= 0)
                return Json(false);

            return Json(true);
        }

        public IActionResult Details(int id)
        {
           Course Course = DbContext.Courses.FirstOrDefault(c => c.Id == id);
           DbContext.Entry<Course>(Course).Reference(c => c.Department).Load();
           DbContext.Entry<Course>(Course).Collection(c => c.Instructores).Load();

            return View(Course);
        }

        public IActionResult DeleteCourse(int id)
        {
            Course Course = DbContext.Courses.FirstOrDefault(c => c.Id == id);

            DbContext.Entry<Course>(Course).Reference(c => c.Department).Load();
            DbContext.Entry<Course>(Course).Collection(c => c.Instructores).Load();

            return View(Course);
        }

        
        public IActionResult AddCourse()
        {
            ViewBag.Departments = DbContext.Departments.Select(Dep => new { Dep.Id, Dep.Name });
            return View();
        }

        public IActionResult EditCourse(int Id)
        {
            ViewBag.Departments = DbContext.Departments.Select(Dep => new { Dep.Id, Dep.Name });
            Course course = DbContext.Courses.FirstOrDefault(c => c.Id==Id);
            return View(course);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SaveNewCourse(Course course)
        {
            if(ModelState.IsValid)
            {
                DbContext.Courses.Add(course);
                DbContext.SaveChanges();
                return RedirectToAction("Details", new {id = course.Id});
            }
            else
            {
                ViewBag.Departments = DbContext.Departments.Select(Dep => new { Dep.Id, Dep.Name });
                return View("AddCourse", course);
            }

        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SaveUpdatedCourse(Course course,int Id)
        {
            course.Id = Id;
            if (ModelState.IsValid)
            {
                DbContext.Update(course);
                DbContext.SaveChanges();
                return RedirectToAction("Details", new { id = course.Id });
            }
            else
            {
                ViewBag.Departments = DbContext.Departments.Select(Dep => new { Dep.Id, Dep.Name });
                return View("EditCourse",course);
            }
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ConfirmCourseDeletion( Course Course)
        {
            //Course Course = DbContext.Courses.FirstOrDefault(c => c.Id == id);
            DbContext.Courses.Remove(Course);

            return View("Index");
        }
    }
}
