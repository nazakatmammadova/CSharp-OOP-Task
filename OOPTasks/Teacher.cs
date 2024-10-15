using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTasks
{
    internal class Teacher:User{
        private static int id = 0;
        public int Id { get; private set; }
        public Teacher()
        {
            Id = ++id;
        }
    }
}
