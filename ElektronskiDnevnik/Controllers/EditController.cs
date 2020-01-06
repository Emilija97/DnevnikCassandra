using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElektronskiDnevnik.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit

        public ActionResult Index()
        {
            Student student = TempData["myStudent"] as Student;
            return View(student);
        }

        [HttpPost]
        public ActionResult Index(CassandraDataLayer.QueryEntities.Student s)
        {
            CassandraDataLayer.DataProvider.EditStudent(s);
            return View(s);
        }
    }
}