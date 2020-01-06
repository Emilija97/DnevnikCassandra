using Cassandra;
using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CassandraDataLayer
{
    public static class DataProvider
    {
        #region School
        public static School GetSchool(string schoolID)
        {
            ISession session = SessionManager.GetSession();
            School school = new School();

            if (session == null)
                return null;

            Row schoolData = session.Execute("select * from \"School\" where \"schoolID\"='" + schoolID + "'").FirstOrDefault();

            if (schoolData != null)
            {
                school.schoolID = schoolData["schoolID"] != null ? schoolData["schoolID"].ToString() : string.Empty;
                school.name = schoolData["name"] != null ? schoolData["name"].ToString() : string.Empty;
                school.phone = schoolData["phone"] != null ? schoolData["phone"].ToString() : string.Empty;
                school.email = schoolData["email"] != null ? schoolData["email"].ToString() : string.Empty;
                school.city = schoolData["city"] != null ? schoolData["city"].ToString() : string.Empty;
                school.address = schoolData["address"] != null ? schoolData["address"].ToString() : string.Empty;
                school.zip = schoolData["zip"] != null ? schoolData["zip"].ToString().ToString() : string.Empty;
            }

            return school;
        }

        public static List<School> GetSchools()
        {
            ISession session = SessionManager.GetSession();
            List<School> schools = new List<School>();


            if (session == null)
                return null;

            var schoolsData = session.Execute("select * from \"School\"");


            foreach (var schoolData in schoolsData)
            {
                School school = new School();
                school.schoolID = schoolData["schoolID"] != null ? schoolData["schoolID"].ToString() : string.Empty;
                school.name = schoolData["name"] != null ? schoolData["name"].ToString() : string.Empty;
                school.phone = schoolData["phone"] != null ? schoolData["phone"].ToString() : string.Empty;
                school.email = schoolData["email"] != null ? schoolData["email"].ToString() : string.Empty;
                school.city = schoolData["city"] != null ? schoolData["city"].ToString() : string.Empty;
                school.address = schoolData["address"] != null ? schoolData["address"].ToString() : string.Empty;
                school.zip = schoolData["zip"] != null ? schoolData["zip"].ToString().ToString() : string.Empty;
                schools.Add(school);
            }



            return schools;
        }

        public static void AddSchool(School s)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet schoolData = session.Execute("insert into \"School\" (\"schoolID\", name, phone, email, city, address, zip)  " +
                "values ('" + s.schoolID + "', '" + s.name + "', '" + s.phone + "', '" + s.email + "', '" + s.city + "', '" + s.address + "', '" + s.zip + "')");

        }

        public static void DeleteSchool(string schoolID)
        {
            ISession session = SessionManager.GetSession();
            School school = new School();

            if (session == null)
                return;

            RowSet schoolData = session.Execute("delete from \"School\" where \"schoolID\" = '" + schoolID + "'");

        }

        #endregion

        #region Teacher

        public static Teacher GetTeacher(string schoolID, string teacherID)
        {
            ISession session = SessionManager.GetSession();
            Teacher teacher = new Teacher();

            if (session == null)
                return null;

            Row teacherData = session.Execute("select * from \"Teacher\" where  \"teacherID\"='" + teacherID + "' and \"schoolID\"='" + schoolID + "'").FirstOrDefault();

            if (teacherData != null)
            {
                teacher.schoolID = teacherData["schoolID"] != null ? teacherData["schoolID"].ToString() : string.Empty;
                teacher.teacherID = teacherData["teacherID"] != null ? teacherData["teacherID"].ToString() : string.Empty;
                teacher.name = teacherData["name"] != null ? teacherData["name"].ToString() : string.Empty;
                teacher.surname = teacherData["surname"] != null ? teacherData["surname"].ToString() : string.Empty;
                teacher.phone = teacherData["phone"] != null ? teacherData["phone"].ToString() : string.Empty;
                teacher.email = teacherData["email"] != null ? teacherData["email"].ToString() : string.Empty;
                teacher.password = teacherData["password"] != null ? teacherData["password"].ToString() : string.Empty;
            }

            return teacher;
        }
        public static string GetTeacherID(string email, string password)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return null;

            Row teacherData = session.Execute("select * from \"Teacher\" where email='" + email + "' and password='" + password + "' allow filtering").FirstOrDefault();

            string teacherID = "";
            if (teacherData != null)
            {
                teacherID = teacherData["teacherID"].ToString();
            }

            return teacherID;
        }

        public static Teacher GetTeacherByEmail(string email, string password)
        {
            ISession session = SessionManager.GetSession();
            Teacher teacher = new Teacher();

            if (session == null)
                return null;

            Row teacherData = session.Execute("select * from \"Teacher\" where email='" + email + "' and password='" + password + "' allow filtering").FirstOrDefault();

            if (teacherData != null)
            {
                teacher.schoolID = teacherData["schoolID"] != null ? teacherData["schoolID"].ToString() : string.Empty;
                teacher.teacherID = teacherData["teacherID"] != null ? teacherData["teacherID"].ToString() : string.Empty;
                teacher.name = teacherData["name"] != null ? teacherData["name"].ToString() : string.Empty;
                teacher.surname = teacherData["surname"] != null ? teacherData["surname"].ToString() : string.Empty;
                teacher.phone = teacherData["phone"] != null ? teacherData["phone"].ToString() : string.Empty;
                teacher.email = teacherData["email"] != null ? teacherData["email"].ToString() : string.Empty;
                teacher.password = teacherData["password"] != null ? teacherData["password"].ToString() : string.Empty;
            }

            return teacher;
        }

        public static List<Teacher> GetTeachers()
        {
            ISession session = SessionManager.GetSession();
            List<Teacher> teachers = new List<Teacher>();

            if (session == null)
                return null;

            var teachersData = session.Execute("select * from \"Teacher\"");

            foreach (var row in teachersData)
            {
                Teacher teacher = new Teacher();
                teacher.schoolID = row["schoolID"] != null ? row["schoolID"].ToString() : string.Empty;
                teacher.teacherID = row["teacherID"] != null ? row["teacherID"].ToString() : string.Empty;
                teacher.name = row["name"] != null ? row["name"].ToString() : string.Empty;
                teacher.surname = row["surname"] != null ? row["surname"].ToString() : string.Empty;
                teacher.phone = row["phone"] != null ? row["phone"].ToString() : string.Empty;
                teacher.email = row["email"] != null ? row["email"].ToString() : string.Empty;
                teacher.password = row["password"] != null ? row["password"].ToString() : string.Empty;

                teachers.Add(teacher);
            }

            return teachers;
        }

        public static void AddTeacher(Teacher t)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet teacherData = session.Execute("insert into \"Teacher\"(\"teacherID\",\"schoolID\", name, surname, phone, email, password) " +
                "values ('" + t.schoolID + "', '" + t.teacherID + "', '" + t.name + "', '" + t.surname + "', '" + t.phone + "', '" + t.email + "','" + t.password + "')");

        }

        public static void DeleteTeacher(string schoolID, string teacherID)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet teacherData = session.Execute("delete from \"Teacher\" where \"teacherID\" = '" + teacherID + "' and \"schoolID\" = '" + schoolID + "'");

        }

        #endregion

        #region Student

        public static Student GetStudent(string studentID, string sectionID, string teacherID)
        {
            ISession session = SessionManager.GetSession();
            Student student = new Student();

            if (session == null)
                return null;

            Row studentData = session.Execute("select * from \"Student\" where \"studentID\" = '" + studentID + "' and \"sectionID\" = '" + sectionID + "' and \"teacherID\" = '" + teacherID + "'").FirstOrDefault();

            if (studentData != null)
            {
                student.studentID = studentData["studentID"] != null ? studentData["studentID"].ToString() : string.Empty;
                student.sectionID = studentData["sectionID"] != null ? studentData["sectionID"].ToString() : string.Empty;
                student.teacherID = studentData["teacherID"] != null ? studentData["teacherID"].ToString() : string.Empty;
                student.name = studentData["name"] != null ? studentData["name"].ToString() : string.Empty;
                student.surname = studentData["surname"] != null ? studentData["surname"].ToString() : string.Empty;
                student.email = studentData["email"] != null ? studentData["email"].ToString() : string.Empty;
                student.password = studentData["password"] != null ? studentData["password"].ToString() : string.Empty;
                student.grades = (SortedDictionary<string, string>)studentData["grades"] != null ? (SortedDictionary<string, string>)studentData["grades"] : new SortedDictionary<string, string>();
            }

            return student;
        }

        public static List<Student> GetStudents(string teacherID)
        {
            ISession session = SessionManager.GetSession();
            List<Student> students = new List<Student>();

            if (session == null)
                return null;

            var studentsData = session.Execute("select * from \"Student\" where \"teacherID\" = '" + teacherID + "' allow filtering");


            foreach (var studentData in studentsData)
            {
                Student student = new Student();
                student.studentID = studentData["studentID"] != null ? studentData["studentID"].ToString() : string.Empty;
                student.sectionID = studentData["sectionID"] != null ? studentData["sectionID"].ToString() : string.Empty;
                student.teacherID = studentData["teacherID"] != null ? studentData["teacherID"].ToString() : string.Empty;
                student.name = studentData["name"] != null ? studentData["name"].ToString() : string.Empty;
                student.surname = studentData["surname"] != null ? studentData["surname"].ToString() : string.Empty;
                student.email = studentData["email"] != null ? studentData["email"].ToString() : string.Empty;
                student.password = studentData["password"] != null ? studentData["password"].ToString() : string.Empty;
                student.grades = (SortedDictionary<string, string>)studentData["grades"] != null ? (SortedDictionary<string, string>)studentData["grades"] : new SortedDictionary<string, string>();
                students.Add(student);
            }


            return students;
        }

        public static string GetStudentID(string email, string password)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return null;

            Row studentData = session.Execute("select * from \"Student\" where email='" + email + "' and password='" + password + "' allow filtering").FirstOrDefault();

            string studentID = "";
            if (studentData != null)
            {
                studentID = studentData["studentID"].ToString();
            }

            return studentID;
        }

        public static Student GetStudentByEmail(string email, string password)
        {
            ISession session = SessionManager.GetSession();
            Student student = new Student();

            if (session == null)
                return null;

            Row studentData = session.Execute("select * from \"Student\" where email='" + email + "' and password='" + password + "' allow filtering").FirstOrDefault();

            if (studentData != null)
            {
                student.studentID = studentData["studentID"] != null ? studentData["studentID"].ToString() : string.Empty;
                student.sectionID = studentData["sectionID"] != null ? studentData["sectionID"].ToString() : string.Empty;
                student.teacherID = studentData["teacherID"] != null ? studentData["teacherID"].ToString() : string.Empty;
                student.name = studentData["name"] != null ? studentData["name"].ToString() : string.Empty;
                student.surname = studentData["surname"] != null ? studentData["surname"].ToString() : string.Empty;
                student.email = studentData["email"] != null ? studentData["email"].ToString() : string.Empty;
                student.password = studentData["password"] != null ? studentData["password"].ToString() : string.Empty;
                student.grades = (SortedDictionary<string, string>)studentData["grades"] != null ? (SortedDictionary<string, string>)studentData["grades"] : new SortedDictionary<string, string>();
            }

            return student;
        }

        public static void AddStudent(Student s)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet studentData = session.Execute("insert into \"Student\"(\"studentID\",\"sectionID\", \"teacherID\", name, surname, email, password, grades) " +
                "values ('" + s.studentID + "', '" + s.sectionID + "', '" + s.teacherID + "', '" + s.name + "', '" + s.surname + "', '" + s.email + "','" + s.password + "', null)");

        }

        public static void DeleteStudent(string studentID, string sectionID, string teacherID)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet studentData = session.Execute("delete from \"Student\" where \"studentID\" = '" + studentID + "' and \"sectionID\" = '" + sectionID + "' and \"teacherID\" = '" + teacherID + "'");

        }

        public static void EditStudent(Student s)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            SortedDictionary<string, string> tmp = s.grades;
            string g = "";
            string keyy = "";
            string val = "";
            bool counter = true;
            foreach (var grade in tmp)
            {
                keyy = grade.Key;
                val = grade.Value;
                if (counter)
                {
                    g += "'" + keyy + "':'" + val + "'";
                    counter = false;
                }
                g += ", '" + keyy + "':'" + val + "'";
            }

            session.Execute("update \"Student\" set name='" + s.name + "', surname='" + s.surname + "', email= '" + s.email + "', password='" + s.password + "', grades = {" + g + "} where \"studentID\"='" + s.studentID + "' and \"sectionID\"='" + s.sectionID + "' and \"teacherID\" = '" + s.teacherID + "'");

        }

        public static void AddSubject(Student s)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;
            string g = "";
            if (s.grades != null)
            {
                SortedDictionary<string, string> tmp = s.grades;

                string keyy = "";
                string val = "";
                bool counter = true;

                foreach (var grade in tmp)
                {
                    keyy = grade.Key;
                    val = grade.Value;
                    if (counter)
                    {
                        g += "'" + keyy + "':'" + val + "'";
                        counter = false;
                    }
                    g += ", '" + keyy + "':'" + val + "'";
                }
                g += ", '" + s.subject + "':'" + s.grade + "'";
            }
            else
            {
                g += "'" + s.subject + "':'" + s.grade + "'";
            }
            session.Execute("update \"Student\" set grades = {" + g + "} where \"studentID\"='" + s.studentID + "' and \"sectionID\"='" + s.sectionID + "' and \"teacherID\" = '" + s.teacherID + "'");

        }

        #endregion

        #region Section

        public static Section GetSection(string name, string teacherID, string schoolID)
        {
            ISession session = SessionManager.GetSession();
            Section section = new Section();

            if (session == null)
                return null;

            Row sectionData = session.Execute("select * from \"Section\" where \"name\"='" + name + "' and \"teacherID\" = '" + teacherID + "' and \"schoolID\" = '" + schoolID + "'").FirstOrDefault();

            if (sectionData != null)
            {
                section.schoolID = sectionData["schoolID"] != null ? sectionData["schoolID"].ToString() : string.Empty;
                section.teacherID = sectionData["teacherID"] != null ? sectionData["teacherID"].ToString() : string.Empty;
                section.num_stud = sectionData["num_stud"] != null ? Int32.Parse(sectionData["num_stud"].ToString()) : 0;
                section.name = sectionData["name"] != null ? sectionData["name"].ToString() : string.Empty;
            }

            return section;
        }

        public static List<Section> GetSections()
        {
            ISession session = SessionManager.GetSession();
            List<Section> sections = new List<Section>();

            if (session == null)
                return null;

            var sectionsData = session.Execute("select * from \"Section\"");


            foreach (Row sectionData in sectionsData)
            {
                Section section = new Section();
                section.schoolID = sectionData["schoolID"] != null ? sectionData["schoolID"].ToString() : string.Empty;
                section.teacherID = sectionData["teacherID"] != null ? sectionData["teacherID"].ToString() : string.Empty;
                section.num_stud = sectionData["num_stud"] != null ? Int32.Parse(sectionData["num_stud"].ToString()) : 0;
                section.name = sectionData["name"] != null ? sectionData["name"].ToString() : string.Empty;

                sections.Add(section);
            }


            return sections;
        }

        public static void ChangeNumStud(string sectionID, string teacherID, string schoolID, int param)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            int numStud = 0;
            var sectionsData = session.Execute("select * from \"Section\" where \"name\"='" + sectionID + "' and \"teacherID\" = '" + teacherID + "' and \"schoolID\" = '" + schoolID + "'");
            foreach (Row sectionData in sectionsData)
            {
                numStud = sectionData["num_stud"] != null ? (Int32.Parse(sectionData["num_stud"].ToString()) + param) : 0;
            }

            session.Execute("update \"Section\" set num_stud=" + numStud + " where \"name\"='" + sectionID + "' and \"teacherID\" = '" + teacherID + "' and \"schoolID\" = '" + schoolID + "'");
        }

        public static void AddSection(Section s)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet sectionData = session.Execute("insert into \"Section\"(\"schoolID\", \"teacherID\", num_stud,  \"name\") " +
                "values ('" + s.schoolID + "', '" + s.teacherID + "', '" + s.num_stud + "', '" + s.name + "')");

        }

        public static void DeleteSection(string sectionID, string teacherID, string schoolID)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet sectionData = session.Execute("delete from \"Section\" where \"sectionID\" = '" + sectionID + "' and \"teacherID\" = '" + teacherID + "'  and \"schoolID\" = '" + schoolID + "'");

        }


        #endregion

        #region Functions

        public static bool ValidateUser(string email, string password, bool teacher)
        {
            ISession session = SessionManager.GetSession();
            List<Section> sections = new List<Section>();

            if (session == null)
                return false;

            if (teacher)
            {
                var sectionsData = session.Execute("select * from \"Teacher\" where email = '" + email + "' and password = '" + password + "' ALLOW FILTERING");
                foreach (Row sectionData in sectionsData)
                {
                    return true;
                }
                return false;
            }
            else
            {
                var sectionsData = session.Execute("select * from \"Student\" where email = '" + email + "' and password = '" + password + "' ALLOW FILTERING");
                foreach (Row sectionData in sectionsData)
                {
                    return true;
                }
                return false;
            }
        }

        #endregion
    }
}
