using OOPTasks;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("1. Yeni istifadeci yarat.");
                Console.WriteLine("2. Istifadecilerin siyahisina bax.");
                Console.WriteLine("3. Elaqe yarat.");
                Console.WriteLine("4. Axtaris elemek.");
                Console.WriteLine("5. Cixis etmek.");
                Console.WriteLine("------------------------------------------------");
                Console.Write("Secim edin (1-5): ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.Write("Duzgun secim edin(1-5): ");
                }
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
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Yanlis secim!!!".ToUpper());
                        break;
                }
                Console.WriteLine("-------------------------------------");
            }
        }

        public static void newUser()
        {
            Console.WriteLine("1. Muellim");
            Console.WriteLine("2. Telebe");
            Console.Write("Secim edin: ");
            int userType;
            while (!int.TryParse(Console.ReadLine(), out userType) || (userType != 1 && userType != 2))
            {
                Console.WriteLine("Duzgun secim edin: Muellim ucun 1, Telebe ucun 2");
            }
            string type = "";
            User u=null;
            if (userType == 1)
            {
                u = new Teacher();
                type = "muellim";
            }
            else if (userType == 2)
            {
                u = new Student();
                type = "telebe";
            }
            newUserType(u, type, userType);
        }
        public static void newUserType(User u, string type, int userType)
        {
            Console.Write($"{type} adi daxil edin: ");
            u.Name = Console.ReadLine();
            Console.Write($"{type} Soyadi daxil edin: ");
            u.Surname = Console.ReadLine();
            Console.Write($"{type} emaili daxil edin: ");
            u.Email = Console.ReadLine();
            Console.Write($"{type} dogum tarixi daxil edin (yyyy-mm-dd): ");
            DateTime birthDate;
            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.Write("Duzgun formatda tarix daxil edin (yyyy-mm-dd): ");
            }
            u.BirthDate = birthDate;
            if (userType == 1)
            {
                Teacher teacher = (Teacher)u;
                DataBase.ListTeachers.Add(teacher);
            }
            else if (userType == 2)
            {
                Student student = (Student)u;
                DataBase.ListStudents.Add(student);
            }
            Console.WriteLine($"{u.Name} {u.Surname} adli {type} yaradildi!");
        }
        public static void displayList()
        {
            Console.WriteLine("1. Muellimlerin siyahisi");
            Console.WriteLine("2. Telebelerin siyahisi");
            Console.Write("Secim edin: ");
            int listType;
            while (!int.TryParse(Console.ReadLine(), out listType) || (listType != 1 && listType != 2))
            {
                Console.WriteLine("Lütfen geçerli bir seçim yapın: 1 Muellim, 2 Telebe");
            }

            if (listType == 1)
            {
                if (DataBase.ListTeachers.Count > 0)
                {
                    Console.WriteLine("Muellimlerin siyahisi:");
                    foreach (Teacher t in DataBase.ListTeachers)
                    {
                        Console.WriteLine($"{t.Id} ID. {t.Name} {t.Surname}");
                    }
                }
                else
                {
                    Console.WriteLine("Muellimlerin siyahisi bosdur.");
                }
            }
            else if (listType == 2)
            {
                if (DataBase.ListStudents.Count > 0)
                {
                    Console.WriteLine("Telebelerin siyahisi:");
                    foreach (Student s in DataBase.ListStudents)
                    {
                        Console.WriteLine($"{s.Id} ID. {s.Name} {s.Surname}");
                    }
                }
                else
                {
                    Console.WriteLine("Telebelerin siyahisi bosdur.");
                }
            }
        }

        public static void newConnections()
        {
            TeacherStudent teacherStudent = new TeacherStudent();
            Console.Write("Muellim ID-si daxil edin: ");
            int teacherId = int.Parse(Console.ReadLine());
            Teacher foundTeacher = DataBase.ListTeachers.FirstOrDefault(t => t.Id == teacherId);
            if (foundTeacher != null)
            {
                teacherStudent.Teacher = foundTeacher;
            }
            else
            {
                Console.WriteLine("Bele bir muellim ID-si yoxdur.");
                return;
            }
            Console.Write("Telebe ID-si daxil edin: ");
            int studentId = int.Parse(Console.ReadLine());
            Student foundStudent = DataBase.ListStudents.FirstOrDefault(s => s.Id == studentId);
            if (foundStudent != null)
            {
                teacherStudent.Student = foundStudent;
            }
            else
            {
                Console.WriteLine("Bele bir telebe ID-si yoxdur.");
                return;
            }
            Console.Write("Muelliminn ders kecdiyi fenni daxil edin: ");
            teacherStudent.Subject = Console.ReadLine();
            Console.Write("Muellimin ders kecdiyi sinifin nomresini daxil edin: ");
            teacherStudent.ClassNumber = Console.ReadLine();
            DataBase.ListTeacherStudents.Add(teacherStudent);
            Console.WriteLine($"{teacherStudent.Teacher.Name} müellim, " +
                $"{teacherStudent.ClassNumber} sinfinde olan {teacherStudent.Student.Name}" +
                $" şagirde {teacherStudent.Subject} fənnindwn dwrs keçir.");
        }

        public static void search()
        {
            Console.WriteLine("1. Bir müellimin ders dediyi şagirdleri görmek");
            Console.WriteLine("2. Bir şagirde ders keçen müellimleri görmek");
            Console.Write("Secim edin (1-2): ");
            int choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                Console.Write("Muellim ID-si daxil edin: ");
                int teacherId = int.Parse(Console.ReadLine());
                Console.WriteLine($"ID-si {teacherId} olan muellimin ders kecdiyi telebelerin siyahisi: ");
                bool found = false;
                foreach (TeacherStudent ts in DataBase.ListTeacherStudents)
                {
                    if (ts.Teacher.Id == teacherId)
                    {
                        Console.WriteLine($"{ts.Student.Name} {ts.Student.Surname}");
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Ders kecilen telebe yoxdur!");
                }
            }
            else if (choose == 2)
            {
                Console.Write("Telebe ID-si daxil edin: ");
                int studentId = int.Parse(Console.ReadLine());
                Console.WriteLine($"ID-si {studentId} olan telebeye ders kecen muellimlerin siyahisi:");
                bool found = false;
                foreach (TeacherStudent ts in DataBase.ListTeacherStudents)
                {
                    if (ts.Student.Id == studentId)
                    {
                        Console.WriteLine($"{ts.Teacher.Name} {ts.Teacher.Surname}");
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Ders kecen muellim yoxdur!");
                }
            }
            else
            {
                Console.WriteLine("Yanlis secim!!");
            }
        }

    }
}