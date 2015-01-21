using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04SoftwareUniversityLearningSystem
    {
    public class OnsiteStudent : CurrentStudent
        {
        private int numberOfVisit;

        public OnsiteStudent(string fname, string lname, int age, int studentNumber, double averageGrade, string curCourse, int numVisit)
            : base(fname, lname, age, studentNumber, averageGrade, curCourse)
            {
            this.NumberOfVisit = numVisit;
            }

        public int NumberOfVisit
            {
            get { return numberOfVisit; }
            set
                {
                if (value < 0)
                    {
                    throw new System.ArgumentException("Number of visit can not be negative.");
                    }
                numberOfVisit = value;
                }
            }
        }
    }
