using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04SoftwareUniversityLearningSystem
    {
    public class CurrentStudent : Student
        {

        private string currentCourse;

        public CurrentStudent(string fname, string lname, int age, int studentNumber, double averageGrade, string curCourse)
            : base(fname, lname, age, studentNumber, averageGrade)
            {
            this.CurrentCourse = curCourse;
            }

        public string CurrentCourse
            {
            get { return currentCourse; }
            set
                {
                if (string.IsNullOrEmpty(value))
                    {
                    throw new System.ArgumentNullException("Current course.");
                    }
                currentCourse = value;
                }
            }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " is " + this.Age + " years old. His student number is " +
                    this.StudentNumber + " and the average grade is " + this.AverageGrade +". Now he is in " + this.CurrentCourse + " course.";
        }
        }
    }
