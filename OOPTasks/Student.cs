using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTasks
{
    internal class Student
    {
        public long Id;
        public string Name;
        public string Surname;
        public Student(long _id,string _name,string _surname)
        {
            this.Id = _id;  
            this.Name = _name;
            this.Surname = _surname;
        }

        public static void CreateStudent(DataBase db)
        {
            Console.WriteLine("Sagirdin adını daxil edin:");
            string name = Console.ReadLine();

            Console.WriteLine("Sagirdin soyadını daxil edin:");
            string surname = Console.ReadLine();

            Student newStudent = new Student(db.Students.Count + 1,name,surname);
            db.Students.Add(newStudent);

            Console.WriteLine("\nYeni sagird ugurla yaradildi.");

        }
    }
}
