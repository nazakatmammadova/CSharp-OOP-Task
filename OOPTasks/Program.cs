using OOPTasks;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OOP task 1

            //while (true)
            //{
            //    Console.Write("maşın yaratmaq isteyirsiniz mi? True or False.\n");
            //    bool cavab = bool.Parse(Console.ReadLine());
            //    if (cavab)
            //    {
            //        Console.Write("Marka (make) daxil edin : ");
            //        string make = Console.ReadLine();
            //        Console.Write("Model daxil edin : ");
            //        string model = Console.ReadLine();
            //        Console.Write("İl (year) daxil edin : ");
            //        int year = int.Parse(Console.ReadLine());
            //        Car car = new Car(make, model, year);
            //        car.DisplayInfo();
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //OOP task 2
            DataBase db = new DataBase();
            while (true)
            {
                Console.WriteLine("\n1) Yeni muellim yaratmaq");
                Console.WriteLine("2) Yeni şagird yaratmaq");
                Console.WriteLine("3) Yeni teacher student elaqesi yaratmaq");
                Console.WriteLine("4) Movcud müellimleri görmek");
                Console.WriteLine("5) Movcud sagirdleri görmek");
                Console.WriteLine("6) Bir şagirde ders keçen müellimleri görmek");
                Console.WriteLine("7) Bir müellimin ders dediyi sagirdleri görmek\n");

                Console.Write("Emeliyyat secin:  ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Teacher.CreateTeacher(db);                
                        break;
                    case 2:
                       Student.CreateStudent(db);
                        break;
                    case 3:
                       TeacherStudent.CreateTeacherStudent(db);
                        break;
                    case 4:
                        DataBase.DisplayTeachers(db);
                        break;
                    case 5:
                        DataBase.DisplayStudents(db);
                        break;
                    case 6:
                       DataBase.DisplayTeachersByStudent(db);
                        break;
                    case 7:
                        DataBase.DisplayStudentsByTeacher(db);
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim. Zehmet olmasa düzgün seçim edin.\n");
                        break;
                }
            }


        }
    }
}