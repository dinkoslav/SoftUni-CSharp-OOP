using System;

namespace Animals
{
    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name", "Name can not be empty!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age can not be negative!");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (value == "male" || value == "female")
                {
                    this.gender = value;
                }
                else
                {
                    throw new ArgumentException("Accepted values for gender are: male and female.");
                }
            }
        }

        public abstract void ProduceSound();
    }
}
