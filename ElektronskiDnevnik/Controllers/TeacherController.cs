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
    }
}