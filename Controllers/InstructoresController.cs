using Asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.net.Controllers
{
    public class InstructoresController : Controller
    {  
        ApplictaionDbContext DbContext = new ApplictaionDbContext();

        public InstructoresController()
        {
            // depenecy Injection
        }
        public IActionResult Index()
        {
            DbSet<Instructore> Instructores = DbContext.Instructores;
            return View( Instructores);
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult FindInstructore()
        {
            ViewBag.Instructores = DbContext.Instructores.Select(I => new {I.Id, I.Name});
            return View();
        }

        public IActionResult InstructoreCard(int Id)
        {
            Instructore instructore = DbContext.Instructores.FirstOrDefault(I => I.Id == Id);
            DbContext.Entry<Instructore>(instructore).Reference(I => I.Department).Load();
            DbContext.Entry<Instructore>(instructore).Reference(I => I.Course).Load();
            return PartialView("_InstructoreCard", instructore);
        }
    }
}
