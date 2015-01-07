using System;

namespace DefiningClasses
    {
    public class Person
        {

        private string name;
        private byte age;
        private string email;

        public Person(string name, byte age, string email)
            {
            this.Name = name;
            this.Age = age;
            this.Email = email;
            }
        public Person(string name, byte age)
            : this(name, age, null)
            {
            this.Name = name;
            this.Age = age;
            }

        public string Name
            {

            get
                {
                return this.name;
                }
            set
                {
                this.name = value;
                }
            }
        public byte Age
            {
            get
                {
                return this.age;
                }
            set
                {
                if (value >= 1 && value <= 100)
                    {
                    this.age = value;
                    }

                else
                    {
                    throw new ArgumentOutOfRangeException("Age must be between 1 and 100.");
                    }
                }
            }
        public string Email
            {
            get
                {
                return this.email;
                }
            set
                {
                if (value == null || value.Contains("@"))
                    {
                    this.email = value;
                    }
                else
                    {
                    throw new ArgumentException("Email must be null or have @");
                    }
                }
            }

        public void ToString()
            {
            if (this.email == null)
                {
                Console.WriteLine("My name is {0}, i'm {1} years old and i don't have email.", this.name, this.age);

                }
            else
                {
                Console.WriteLine("My name is {0}, i'm {1} years old and my email is {2}.", this.name, this.age, this.email);
                }
            }
        }
    }
