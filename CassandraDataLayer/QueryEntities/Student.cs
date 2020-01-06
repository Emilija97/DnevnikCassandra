using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraDataLayer.QueryEntities
{
    public class Student
    {
        public string studentID { get; set; }

        [Required(ErrorMessage = "Section ID is required.")]
        public string sectionID { get; set; }

        [Required(ErrorMessage = "Teacher ID is required.")]
        public string teacherID { get; set; }

        public string name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        public string surname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        //[DataType(DataType.Password)]
        public string password { get; set; }

        public SortedDictionary<string, string> grades { get; set; }

        public string subject { get; set; }
        public string grade { get; set; }
    }
}
