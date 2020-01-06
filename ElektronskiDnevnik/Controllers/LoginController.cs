using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElektronskiDnevnik.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(CassandraDataLayer.QueryEntities.User u)
        {
            bool temp = CassandraDataLayer.DataProvider.ValidateUser(u.email, u.password, u.role);

            if (temp)
            {
                if(u.role)
                {
                    //u.userID = CassandraDataLayer.DataProvider.GetTeacherID(u.email, u.password);
                    Teacher teacher = CassandraDataLayer.DataProvider.GetTeacherByEmail(u.email, u.password);
                    u.userID = teacher.teacherID;
                    u.name = teacher.name;
                    u.surname = teacher.surname;
                    u.schoolID = teacher.schoolID;
                    CassandraDataLayer.Store.GetInstance().SetUser(u);
                    return Redirect("/Teacher/Teacher");
                }
                else
                {
                    //u.userID = CassandraDataLayer.DataProvider.GetStudentID(u.email, u.password);
                    Student student = CassandraDataLayer.DataProvider.GetStudentByEmail(u.email, u.password);
                    u.userID = student.studentID;
                    u.name = student.name;
                    u.surname = student.surname;
                    u.sectionID = student.sectionID;
                    u.teacherID = student.teacherID;
                    CassandraDataLayer.Store.GetInstance().SetUser(u);
                    return Redirect("~/Home");
                }
                //return Redirect("~/Home");
            }
            ViewBag.Message = "Your email, password or role is incorrect!";
            return Login();

        }

        [HttpGet]
        public ActionResult Logout()
        {
            bool temp = CassandraDataLayer.Store.GetInstance().SetUser(null);
            return Redirect("~/Home");
        }
    }
}