using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTasks
{
    internal class TeacherStudent
    {
        public long Id;
        public Teacher Teacher;
        public Student Student;
        public string Subject;
        public string ClassNumber;

        public TeacherStudent(long _id,Teacher t,Student s,string _sub,string num)
        {
            this.Id = _id;  
            this.Teacher = t;
            this.Student = s;
            this.Subject = _sub;
            this.ClassNumber = num;
        }
        public static void CreateTeacherStudent(DataBase db)
        {
            Console.WriteLine("Muellimin ID'sini daxil edin:");
            long teacherId = long.Parse(Console.ReadLine());

            Console.WriteLine("Sagirdin ID'sini daxil edin:");
            long studentId = long.Parse(Console.ReadLine());

            Console.WriteLine("Movzu adını daxil edin:");
            string subject = Console.ReadLine();

            Console.WriteLine("Sinif nömresini daxil edin:");
            string classNumber = Console.ReadLine();

            TeacherStudent newTeacherStudent = new TeacherStudent(db.TeacherStudents.Length + 1, DataBase.GetTeacherById(teacherId), DataBase.GetStudentById(studentId),subject,classNumber);

            Array.Resize(ref db.TeacherStudents, db.TeacherStudents.Length + 1);
            db.TeacherStudents[db.TeacherStudents.Length - 1] = newTeacherStudent;

            Console.WriteLine("\nYeni teacher-student elaqesi ugurla yaradildi.");
        }

    }
}
