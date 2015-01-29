using System;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy
{
    public class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        public Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 1000 || value > 9999)
                {
                    throw new ArgumentOutOfRangeException("id", "ID must be in range [1000...9999].");
                }

                this.id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("firstName", "First name can not be null or empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("lastName", "Last name can not be null or empty.");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return this.firstName + " " + this.lastName + ", " + "ID: " + this.id;
        }
    }
}
