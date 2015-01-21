

namespace Problem04SoftwareUniversityLearningSystem
    {
    public class Person
        {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
            {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            }

        public int Age
            {
            get { return age; }
            set
                {
                if (value < 0)
                    {
                    throw new System.ArgumentException("Age can not be negative.");
                    }
                age = value;
                }
            }

        public string LastName
            {
            get { return lastName; }
            set
                {
                if (string.IsNullOrEmpty(value))
                    {
                    throw new System.ArgumentNullException("Last name.");
                    }
                lastName = value;
                }
            }

        public string FirstName
            {
            get { return firstName; }
            set
                {
                if (string.IsNullOrEmpty(value))
                    {
                    throw new System.ArgumentNullException("First name.");
                    }
                firstName = value;
                }
            }

        }
    }
