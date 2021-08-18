using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Exam.Models;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GiveStudents();
            return View();
        }

       /* public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/
        private StudentContext db = new StudentContext();
        private void GiveStudents()
        {
            var allStudents = db.Students.ToList<Student>();
            ViewBag.Students = allStudents;
        }
        [HttpGet]
        public ActionResult CreateBid()
        {
            GiveStudents();
            var allBids = db.Students.ToList<Student>();
            ViewBag.Students = allBids;
            return View();
        }

        [HttpPost]
        public string CreateBid(Student newBid)
        {            
            // Добавляем новую заявку в БД
            db.Students.Add(newBid);
            // Сохраняем в БД все изменения
            db.SaveChanges();
            return "Студент, <b>" + newBid.FirstName + newBid.LastName + "</b> добавлен";
        }

        public ActionResult TotalSerch_max()
        {             
            var students = "";
            foreach (var item in db.Students.ToList<Student>().OrderByDescending(s => s.Total).Take(5))
            {
                students += item.FirstName + " " + item.LastName + " " + item.Total + Environment.NewLine;
            }
            var byteArray = Encoding.UTF8.GetBytes(students);
            var stream = new MemoryStream(byteArray);
            return File(stream, "text/plain", "Список студентов_max.txt");
        }
        public ActionResult TotalSerch_min()
        {
           
            var students = "";
            foreach (var item in db.Students.ToList<Student>().OrderBy(s => s.Total).Take(5))
            {
                students += item.FirstName + " " + item.LastName + " " + item.Total + Environment.NewLine;
            }
            var byteArray = Encoding.UTF8.GetBytes(students);
            var stream = new MemoryStream(byteArray);
            return File(stream, "text/plain", "Список студентов_min.txt");
        }
        



    }
}