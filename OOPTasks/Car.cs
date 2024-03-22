using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOPTasks
{
    internal class Car
    {
        private string make;
        private string model;
        private int year;
        private static int maxSpeedLimit = 120;

        public Car(string _make, string _model, int _year)
        {
            this.make = _make;
            this.model = _model;
            this.year = _year;
        }
        public static int GetMaxSpeedLimit()
        {
            return maxSpeedLimit;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Make: " + make);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Year: " + year);
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public static int MaxSpeedLimit
        {
            get { return maxSpeedLimit; }
            set { maxSpeedLimit = value; }
        }
    }
}
