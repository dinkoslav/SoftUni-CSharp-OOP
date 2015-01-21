using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04SoftwareUniversityLearningSystem
    {
    public class GraduateStudent : Student
        {
        public GraduateStudent(string fname, string lname, int age, int studentNumber, double averageGrade)
            : base(fname, lname, age, studentNumber, averageGrade)
            {
            }
        }
    }
