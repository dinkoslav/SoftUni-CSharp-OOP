using System;
using System.Collections.Generic;

namespace School
{
    public class Teacher : People
    {
        private IList<Discipline> disciplines;

        public Teacher(string name, IList<Discipline> disciplines, string details)
            : base(name, details)
        {
            this.Disciplines = disciplines;
        }

        public IList<Discipline> Disciplines
        {
            get { return new List<Discipline>(this.disciplines); }
            set
            {
                if (value == null || value.Count < 1)
                {
                    throw new ArgumentException("Disciplines list can not be null or 0!");
                }

                this.disciplines = value;
            }
        }
    }
}
