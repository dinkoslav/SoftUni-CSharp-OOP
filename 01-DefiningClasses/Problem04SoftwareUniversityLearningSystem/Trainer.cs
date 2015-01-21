using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04SoftwareUniversityLearningSystem
    {
    public class Trainer : Person
        {
        public Trainer(string fname, string lname, int age)
            : base(fname, lname, age)
            {

            }

        public void CreateCourse(string courseName)
            {
            Console.WriteLine("{0} has been created.", courseName);
            }
        }
    }
