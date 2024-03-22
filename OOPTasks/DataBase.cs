using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTasks
{
    internal class DataBase
    {
        public Teacher[] Teachers ;
        public Student[] Students;
        public TeacherStudent[] TeacherStudents;

        public DataBase()
        {
                Teachers = new Teacher[]
                   {
                        new Teacher(1, "Gulshan", "Settarova"),
                        new Teacher(2, "Nazli", "Memmedova")
                   };
                 Students = new Student[]
                   {
                        new Student(1, "Ilkin", "Eliyev"),
                        new Student(2, "Yunis", "Memmedov"),
                        new Student(3, "Huseyn", "Eliyev"),
                        new Student(4, "Efsane", "Abdullayeva"),
                        new Student(5, "Ayxan", "Abdullayev")
                   };
                    TeacherStudents = new TeacherStudent[]
                    {
                                new TeacherStudent(1,Teachers[0],Students[0],"C#","681.21"),
                                new TeacherStudent(2,Teachers[0],Students[1],"C#","681.21"),
                                new TeacherStudent(3,Teachers[1],Students[2],"React","681.21"),
                                new TeacherStudent(4,Teachers[1],Students[3],"React","685.21"),
                                new TeacherStudent(5,Teachers[1],Students[4],"React","681.21"),
                                new TeacherStudent(6,Teachers[1],Students[0],"React","681.21"),
                                new TeacherStudent(7,Teachers[1],Students[1],"React","681.21"),
                                new TeacherStudent(8,Teachers[0],Students[2],"C#","681.21"),
                                new TeacherStudent(9,Teachers[0],Students[3],"C#","685.21"),
                                new TeacherStudent(10,Teachers[0],Students[4],"C#","681.21")
                    };

        }
        public static void DisplayTeachers(DataBase db)
        {
            if (db.Teachers.Length == 0)
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
            if (db.Students.Length == 0)
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
