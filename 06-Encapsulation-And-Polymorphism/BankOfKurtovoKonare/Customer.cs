using System;

namespace BankOfKurtovoKonare
{
    public abstract class Customer
    {
        private string address;
        private string phone;

        public Customer(string address, string phone)
        {
            this.Address = address;
            this.Phone = phone;
        }

        public string Address
        {
            get { return this.address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("address");
                }

                this.address = value;
            }
        }

        public string Phone
        {
            get { return this.phone; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("phone");
                }

                this.phone = value;
            }
        }

        public override string ToString()
        {
            return "Address: " + this.address + "\nPhone: " + this.phone + "\n";
        }
    }
}
