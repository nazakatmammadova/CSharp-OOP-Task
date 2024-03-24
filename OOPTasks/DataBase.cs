using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTasks
{
    internal class DataBase
    {
        public List<Teacher> Teachers= new List<Teacher> {new Teacher(1, "Gulshan", "Settarova"),new Teacher(2, "Nazli", "Memmedova")};
        public List<Student> Students=new List<Student> {new Student(1, "Ilkin", "Eliyev"),
                        new Student(2, "Yunis", "Memmedov"),
                        new Student(3, "Huseyn", "Eliyev"),
                        new Student(4, "Efsane", "Abdullayeva"),
                        new Student(5, "Ayxan", "Abdullayev")};
        public List<TeacherStudent> TeacherStudents;
        public static void DisplayTeachers(DataBase db)
        {
            if (db.Teachers.Count == 0)
            {
                Console.WriteLine("\nMuellim Yoxdur!");
            }
            else
            {
                Console.WriteLine("\nMövcud müellimler:");
                foreach (var teacher in db.Teachers)
                {
                    Console.WriteLine($"{teacher.Id}. {teacher.Name} {teacher.Surname}");
                }
            }
        }
        public static void DisplayStudents(DataBase db)
        {
            if (db.Students.Count == 0)
            {
                Console.WriteLine("Sagird Yoxdur!");
            }
            else
            {
                Console.WriteLine("\nMövcud sagirdler:");
                foreach (var student in db.Students)
                {
                    Console.WriteLine($"{student.Id}) {student.Name} {student.Surname}");
                }
            }
        }

        public static DataBase db = new DataBase();
        public static Teacher GetTeacherById(long id)
        {
            foreach (var teacher in db.Teachers)
            {
                if (teacher.Id == id)
                {
                    return teacher;
                }
            }
            return null;
        }

        public static Student GetStudentById(long id)
        {
            foreach (var student in db.Students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public static void DisplayStudentsByTeacher(DataBase db)
        {
            Console.WriteLine("Müellimin ID'sini daxil edin:");
            long teacherId = long.Parse(Console.ReadLine());

            Teacher teacher = GetTeacherById(teacherId);
            if (teacher != null)
            {
                Console.WriteLine($"\n{teacher.Name} {teacher.Surname} adlı müellimin ders dediyi sagirdler:");

                foreach (var teacherStudent in db.TeacherStudents)
                {
                    if (teacherStudent.Teacher.Id == teacherId)
                    {
                        Console.WriteLine($"{teacherStudent.Student.Id} . {teacherStudent.Student.Name} {teacherStudent.Student.Surname}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Belirtilen ID'ye uygun müellim tapılmadı.");
            }
        }
        public static void DisplayTeachersByStudent(DataBase db)
        {
            Console.WriteLine("Telebe ID'sini daxil edin:");
            long StudentId = long.Parse(Console.ReadLine());

            Student st = GetStudentById(StudentId);
            if (st != null)
            {
                Console.WriteLine($"\n{st.Name} {st.Surname} adlı telebenin muellimleri: ");

                foreach (var teacherStudent in db.TeacherStudents)
                {
                    if (teacherStudent.Student.Id == StudentId)
                    {
                        Console.WriteLine($"{teacherStudent.Teacher.Id} . {teacherStudent.Teacher.Name} {teacherStudent.Teacher.Surname}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Belirtilen ID'ye uygun telebe tapılmadı.");
            }
        }
    }
}
