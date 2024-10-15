using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTasks
{
    internal class TeacherStudent
    {
        private static int id = 0;
        public int Id { get; private set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public string Subject { get; set; }
        public string ClassNumber { get; set; }
        public TeacherStudent()
        {
            Id = ++id;
        }
    }
}
