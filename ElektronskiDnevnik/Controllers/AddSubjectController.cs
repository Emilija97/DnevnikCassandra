using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElektronskiDnevnik.Controllers
{
    public class AddSubjectController : Controller
    {
        // GET: AddSubject
        public ActionResult Index()
        {
            Student student = TempData["myStudent"] as Student;
            return View(student);
        }

        [HttpPost]
        public ActionResult Index(CassandraDataLayer.QueryEntities.Student s)
        {
            CassandraDataLayer.DataProvider.AddSubject(s);
            Student student = CassandraDataLayer.DataProvider.GetStudent(s.studentID, s.sectionID, s.teacherID);
            return View(student);
        }
    }
}