using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student
    {
        public string Name { get; }
        public int Mark { get; }

        public Student(string name, int mark)
        {
            Name = name;
            Mark = mark;
        }
    }
}
