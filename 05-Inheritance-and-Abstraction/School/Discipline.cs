using System;
using System.Collections.Generic;

namespace School
{
    public class Discipline : IDetails
    {
        private string name;
        private int numberOfLectures;
        private IList<Student> students;
        private string details;

        public Discipline(string name, int numberOfLectures, IList<Student> students, string details = null)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.Students = students;
            this.Details = details;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Discipline name can not be null or empty!");
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }


        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            set { this.numberOfLectures = value; }
        }

        public IList<Student> Students
        {
            get { return new List<Student>(this.students); }
            set
            {
                if (value == null || value.Count < 1)
                {
                    throw new ArgumentException("Students list can not be null or 0!");
                }

                this.students = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Details can not be empty!");
                }

                this.details = value;
            }
        }
    }
}
