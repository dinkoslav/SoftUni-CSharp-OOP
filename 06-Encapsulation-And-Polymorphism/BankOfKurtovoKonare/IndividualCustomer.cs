using System;
namespace BankOfKurtovoKonare
{
    public class IndividualCustomer : Customer
    {
        private string firstName;
        private string lastName;
        private long pin;

        public IndividualCustomer(string firstName, string lastName, long pin, string address, string phone) 
            : base(address, phone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Pin = pin;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("firstName");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("lastName");
                }

                this.lastName = value;
            }
        }

        public long Pin
        {
            get { return this.pin; }
            set
            {
                if (value < 1000000000 || value > 9999999999)
                {
                    throw new ArgumentException("PIN must be 10 digits number!");
                }

                this.pin = value;
            }
        }

        public override string ToString()
        {
            return "Customer name: " + this.firstName + " " + this.lastName + "\n" +
                "Type: Individual\n" + "PIN: " + this.pin + "\n" + base.ToString();
        }
    }
}
