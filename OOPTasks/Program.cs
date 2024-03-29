using OOPTasks;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase();
            while (true)
            {
                Console.WriteLine("Create new User: 1");
                Console.WriteLine("Display list: 2");
                Console.WriteLine("Connections: 3");
                Console.WriteLine("Search: 4");
                Console.WriteLine("Exit program: 5");
                Console.WriteLine("------------------------------------------------");
                Console.Write("Choose the variant:  ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        newUser();               
                        break;
                    case 2:
                        displayList();
                        break;
                    case 3:
                        newConnections();
                        break;
                    case 4:
                        search();
                        break;
                    default:
                        Console.WriteLine("Not Choice!");
                        break;
                }
                if (choice == 5)
                {
                    break;
                }
                Console.WriteLine("-------------------------------------");
            }
        }
        public static void newUser()
        {
            Console.WriteLine("Teacher: 1");
            Console.WriteLine("Student: 2");
            Console.Write("Choose: ");
            int userType=int.Parse(Console.ReadLine());
            string type="";
            User u=null;
            if (userType == 1)
            {
                u = new Teacher();
                type = "teacher";
            }
            else if(userType == 2)
            {
                u= new Student();
                type = "student";
            }
            else
            {
                Console.WriteLine("Not userType!");
            }
            newUserType(u, type,userType);
        }
        public static void newUserType(User u,string type,int userType)
        {
            Console.WriteLine($"Insert {type} Id: ");
            u.Id = long.Parse(Console.ReadLine());
            Console.WriteLine($"Insert {type} Name: ");
            u.Name = Console.ReadLine();
            Console.WriteLine($"Insert {type} Surname: ");
            u.Surname = Console.ReadLine();
            if(userType == 1)
            {
                DataBase.ListTeachers.Add((Teacher)u);
            }else if (userType==2)
            {
                DataBase.ListStudents.Add((Student)u);
            }
        }
        public static void displayList()
        {
            Console.WriteLine("Teacher List: 1");
            Console.WriteLine("Student List: 2");
            int listType = int.Parse(Console.ReadLine());
            if(listType == 1)
            {
                foreach(Teacher t in DataBase.ListTeachers)
                {
                    Console.WriteLine($"{t.Name} {t.Surname}");
                }
            }else if(listType == 2)
            {
                foreach (Student s in DataBase.ListStudents)
                {
                    Console.WriteLine($"{s.Name} {s.Surname}");
                }
            }
            else
            {
                Console.WriteLine("Not list!");
            }
        }
        public static void newConnections()
        {
            TeacherStudent teacherStudent = new TeacherStudent();
            Console.Write("TeacherStudent Id: ");
            teacherStudent.Id=int.Parse(Console.ReadLine());
            Console.Write("Teacher Id: ");
            int teacherId=int.Parse(Console.ReadLine());
            Console.Write("Student Id: ");
            int studentId=int.Parse(Console.ReadLine());
            foreach (Teacher t in DataBase.ListTeachers)
            {
                if (t.Id==teacherId)
                {
                    teacherStudent.Teacher = t;
                }
            }
            foreach (Student s in DataBase.ListStudents)
            {
                if(s.Id==studentId)
                {
                    teacherStudent.Student = s;
                }
            }
            Console.Write("TeacherStudent subject: ");
            teacherStudent.Subject = Console.ReadLine();
            Console.Write("TeacherStudent classNumber: ");
            teacherStudent.ClassNumber = Console.ReadLine();
            DataBase.ListTeacherStudents.Add(teacherStudent);
        }
        public static void search()
        {
            Console.WriteLine("Teacher to Students: 1");
            Console.WriteLine("Student to Teachers: 2");
            int choose=int.Parse(Console.ReadLine());
            if(choose==1)
            {
                Console.Write("Teacher Id: ");
                int id=int.Parse(Console.ReadLine());
                Console.WriteLine("Student list: ");
                foreach (TeacherStudent ts in DataBase.ListTeacherStudents)
                {
                    if (ts.Teacher.Id == id)
                    {
                        Console.WriteLine($"{ts.Student.Name} {ts.Student.Surname}");
                    }
                }
            }
            else if(choose==2)
            {
                Console.Write("Student Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Teacher list: ");
                foreach (TeacherStudent ts in DataBase.ListTeacherStudents)
                {
                    if (ts.Student.Id == id)
                    {
                        Console.WriteLine($"{ts.Teacher.Name} {ts.Teacher.Surname}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Not Connect!");
            }
        }
    }
}