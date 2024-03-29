using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTasks
{
    internal class TeacherStudent
    {
        public long Id { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public string Subject { get; set; }
        public string ClassNumber { get; set; }
    }
}
