using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTasks
{
    internal static class DataBase
    {
        public static List<Teacher> ListTeachers = new List<Teacher>();
        public static List<Student> ListStudents = new List<Student>();
        public static List<TeacherStudent> ListTeacherStudents=new List<TeacherStudent>();
        static DataBase()
        {
            ListTeachers.Add(new Teacher { Name = "Nazli", Surname = "Memmedova",Email="nazlimammadova@gmail.com",BirthDate=new DateTime(2000,4,7) });
            ListTeachers.Add(new Teacher { Name = "Gulshan", Surname = "Settarova",Email="gulshansettarova@gmail.com",BirthDate=new DateTime(1996,6,1) });
            ListStudents.Add(new Student { Name = "Kenan", Surname = "Memmedov",Email="kenanmammadov@gmail.com",BirthDate=new DateTime(2002,2,12)});
        }
    }
}
