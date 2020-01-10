using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElektronskiDnevnik.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Teacher()
        {
            var students = new List<Student>();
            var teacherID = CassandraDataLayer.Store.GetInstance().loggedUser.userID;
            students = CassandraDataLayer.DataProvider.GetStudents(teacherID);
            return View(students);
        }

        public ActionResult Edit(string id, string sectionID)
        {
            var teacherID = CassandraDataLayer.Store.GetInstance().loggedUser.userID;
            Student student = CassandraDataLayer.DataProvider.GetStudent(id, sectionID, teacherID);
            TempData["myStudent"] = student;
            return RedirectToAction("Index", "Edit");
        }

        public ActionResult AddSubject(string id, string sectionID)
        {
            var teacherID = CassandraDataLayer.Store.GetInstance().loggedUser.userID;
            Student student = CassandraDataLayer.DataProvider.GetStudent(id, sectionID, teacherID);
            TempData["myStudent"] = student;
            return RedirectToAction("Index", "AddSubject");
        }

        public ActionResult Delete(string id, string sectionID)
        {
            User u = CassandraDataLayer.Store.GetInstance().GetUser();
            CassandraDataLayer.DataProvider.DeleteStudent(id, sectionID, u.userID);
            CassandraDataLayer.DataProvider.ChangeNumStud(sectionID, u.userID, u.schoolID, -1);
            return RedirectToAction("Teacher", "Teacher");
        }
        public ActionResult AddSection()
        {
            return View("AddSection");
        }
        [HttpPost]
        public ActionResult AddSection(CassandraDataLayer.QueryEntities.Section s)
        {
            s.schoolID = Guid.NewGuid().ToString("N");
            CassandraDataLayer.DataProvider.AddSection(s);
            return View();
        }
        public ActionResult AddSchool()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSchool(CassandraDataLayer.QueryEntities.School s)
        {
            s.schoolID = Guid.NewGuid().ToString("N");
            CassandraDataLayer.DataProvider.AddSchool(s);
            return View();
        }

        public ActionResult Opinions()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Opinions(CassandraDataLayer.QueryEntities.Section section)
        {
            User u = CassandraDataLayer.Store.GetInstance().GetUser();
            CassandraDataLayer.DataProvider.AddOpinion(section.name, u.userID, u.schoolID, section.opinion);
            return View();
        }
    }
}