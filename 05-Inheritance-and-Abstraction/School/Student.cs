using System;

namespace School
{
    public class Student : People
    {
        private int classNumber;

        public Student(string name, int classNumber, string details)
            :base(name, details)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get { return this.classNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Class number can not be 0 or negative!");
                }

                this.classNumber = value;
            }
        }
    }
}
