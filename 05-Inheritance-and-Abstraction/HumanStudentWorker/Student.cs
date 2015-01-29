using System;
using System.Text.RegularExpressions;

namespace HumanStudentWorker
{
    class Student : Human
    {
        private string facultyNumber;

        public string FacultiNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Faculty number length must be in range [5...10].");
                }

                Regex allowedCharacters = new Regex("^[A-Z0-9]+$");
                if (!allowedCharacters.IsMatch(value))
                {
                    throw new ArgumentException("Faculty number must contain only letters or digits!");
                }

                this.facultyNumber = value;
            }
        }

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultiNumber = facultyNumber;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.FacultiNumber;
        }
    }
}
