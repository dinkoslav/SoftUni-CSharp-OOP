using System;
namespace BankOfKurtovoKonare
{
    public class CompanyCustomer : Customer
    {
        private string name;
        private int unifiedIdentificationCode;

        public CompanyCustomer(string name, int unifiedIdentificationCode, string address, string phone) 
            : base(address, phone)
        {
            this.Name = name;
            this.UnifiedIdentificationCode = unifiedIdentificationCode;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("company name");
                }
                this.name = value;
            }
        }

        public int UnifiedIdentificationCode
        {
            get { return unifiedIdentificationCode; }
            set
            {
                if (value < 100000000 || value > 999999999)
                {
                    throw new ArgumentException("unifiedIdentificationCode must be 9 digits number!");
                }
                unifiedIdentificationCode = value;
            }
        }

        public override string ToString()
        {
            return "Customer name: " + this.name + "\n" + "Type: Company\n" +
                "UIC: " + this.unifiedIdentificationCode + "\n" + base.ToString();
        }
    }
}
