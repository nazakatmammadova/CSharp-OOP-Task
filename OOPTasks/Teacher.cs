using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTasks
{
    internal class Teacher
    {
        public long Id;
        public string Name;
        public string Surname;
        public Teacher(long _id,string _name,string _surname)
        {
            this.Id = _id;
            this.Name = _name;
            this.Surname = _surname;
        }
        public static void CreateTeacher(DataBase db)
        {
            Console.WriteLine("Müellimin adını daxil edin:");
            string name = Console.ReadLine();

            Console.WriteLine("Müellimin soyadını daxil edin:");
            string surname = Console.ReadLine();

            Teacher newTeacher = new Teacher(db.Teachers.Length + 1, name,surname);
            Array.Resize(ref db.Teachers, db.Teachers.Length + 1);
            db.Teachers[db.Teachers.Length - 1] = newTeacher;

            Console.WriteLine("\nYeni muellim ugurla yaradildi.");
        }
    }
}
