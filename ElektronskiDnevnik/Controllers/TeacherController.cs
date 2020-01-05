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
            return Redirect("/Teacher/Edit");
        }

        public ActionResult Details(string id, string sectionID)
        {
            var students = new List<Student>();
            var teacherID = CassandraDataLayer.Store.GetInstance().loggedUser.userID;
            students = CassandraDataLayer.DataProvider.GetStudents(teacherID);
            return View(students);
        }

        public ActionResult Delete(string id, string sectionID)
        {
            var teacherID = CassandraDataLayer.Store.GetInstance().loggedUser.userID;
            CassandraDataLayer.DataProvider.DeleteStudent(id, sectionID, teacherID);
            return View();
        }
    }
}