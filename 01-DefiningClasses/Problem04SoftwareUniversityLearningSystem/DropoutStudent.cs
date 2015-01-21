using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04SoftwareUniversityLearningSystem
    {
    public class DropoutStudent : Student
        {

        private string dropoutReason;

        public DropoutStudent(string fname, string lname, int age, int studentNumber, double averageGrade, string dropReason)
            : base(fname, lname, age, studentNumber, averageGrade)
            {
            this.DropoutReason = dropReason;
            }

        public string DropoutReason
            {
            get { return dropoutReason; }
            set
                {
                if (string.IsNullOrEmpty(value))
                    {
                    throw new System.ArgumentNullException("Dropout reason.");
                    }
                dropoutReason = value;
                }
            }

        public void Reapply()
        {
            Console.WriteLine("{0} {1} - {2} age old", this.FirstName, this.LastName, this.Age);
            Console.WriteLine("Student number: {0}", this.StudentNumber);
            Console.WriteLine("Average grade: {0}", this.AverageGrade);
            Console.WriteLine("Dropout reason: {0}", this.DropoutReason);
        }
        }
    }
