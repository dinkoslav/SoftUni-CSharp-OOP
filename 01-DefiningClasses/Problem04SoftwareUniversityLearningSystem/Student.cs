using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04SoftwareUniversityLearningSystem
    {
    public class Student : Person
        {

        private int studentNumber;
        private double averageGrade;

        public Student(string fname, string lname, int age, int studentNumber, double averageGrade)
            : base(fname, lname, age)
            {
            this.AverageGrade = averageGrade;
            this.StudentNumber = studentNumber;
            }

        public double AverageGrade
            {
            get { return averageGrade; }
            set
                {
                if (value < 0)
                    {
                    throw new System.ArgumentException("Average grade can not be negative.");
                    }
                averageGrade = value;
                }
            }

        public int StudentNumber
            {
            get { return studentNumber; }
            set
                {
                if (value < 0)
                    {
                    throw new System.ArgumentException("Student number can not be negative.");
                    }
                studentNumber = value;
                }
            }

        }
    }
