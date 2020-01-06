using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElektronskiDnevnik.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            User u = CassandraDataLayer.Store.GetInstance().GetUser();
            Student s = CassandraDataLayer.DataProvider.GetStudent(u.userID, u.sectionID, u.teacherID);
            return View(s);
        }
    }
}