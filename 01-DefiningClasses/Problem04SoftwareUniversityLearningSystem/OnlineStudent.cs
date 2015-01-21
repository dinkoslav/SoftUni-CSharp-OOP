using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04SoftwareUniversityLearningSystem
    {
    public class OnlineStudent : CurrentStudent
        {
        public OnlineStudent(string fname, string lname, int age, int studentNumber, double averageGrade, string curCourse)
            : base(fname, lname, age, studentNumber, averageGrade, curCourse)
            {
            }
        }
    }
