using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CommonTypeSystem
{
    class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private int id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private IList<Payment> payments;
        private CustomerType customerType;

        public Customer(string firstName, string middleName, string lastName, int id, string permanentAddress, string mobilePhone, string email, IList<Payment> payments, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }

        public CustomerType CustomerType
        {
            get { return this.customerType; }
            set { this.customerType = value; }
        }

        public IList<Payment> Payments
        {
            get { return this.payments; }
            set { this.payments = value; }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email is invalid");
                }
                this.email = value;
            }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Mobile phone can not be empty");
                }
                this.mobilePhone = value;
            }
        }

        public string PermanentAddress
        {
            get { return this.permanentAddress; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Permanent address can not be empty");
                }
                this.permanentAddress = value;
            }
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ID can not be negative");
                }
                this.id = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Middle name can not be empty");
                }
                this.middleName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name can not be empty");
                }
                this.lastName = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name can not be empty");
                }
                this.firstName = value;
            }
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            if (customer == null)
            {
                return false;
            }

            bool isFirstNameEqual = Object.Equals(this.firstName, customer.firstName);
            bool isLastNameEqual = Object.Equals(this.lastName, customer.lastName);
            bool isMiddleNameEqual = Object.Equals(this.middleName, customer.middleName);
            bool isMobilePhoneEqual = Object.Equals(this.mobilePhone, customer.mobilePhone);
            bool isPermanentAddressEqual = Object.Equals(this.permanentAddress, customer.permanentAddress);
            bool isEmailEqual = Object.Equals(this.email, customer.email);
            bool isIdEqual = this.id == customer.id;
            bool isCustomerTypeEqual = this.customerType.CompareTo(customer.customerType) == 0;

            var thisPayments = this.Payments.OrderBy(p => p).ToList();
            var customerPayments = customer.Payments.OrderBy(p => p).ToList();
            //var diff = ((customerPayments.Except(thisPayments)).Union(thisPayments.Except(customerPayments))).ToList();
            //bool isPaymentsEqual = diff.Count == 0;

            bool isPaymentsEqual = Enumerable.SequenceEqual(thisPayments, customerPayments);

            if (!isFirstNameEqual || !isLastNameEqual || !isMiddleNameEqual || !isMobilePhoneEqual ||
                !isPermanentAddressEqual || !isEmailEqual || !isIdEqual || !isPaymentsEqual || !isCustomerTypeEqual)
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return Equals(c1, c2);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !Equals(c1, c2); ;
        }

        public override string ToString()
        {
            string output = "";
            output += "Customer name : " + this.firstName + " " + this.middleName + " " + this.lastName + "\n";
            output += "Id : " + this.id + "\n";
            output += "Mobile phone : " + this.mobilePhone + "\n";
            output += "Permanent address : " + this.permanentAddress + "\n";
            output += "Email : " + this.email + "\n";
            output += "Customer type : " + this.customerType + "\n";
            output += "Payments : \n";

            foreach (var payment in this.payments)
            {
                output += "Product name: " + payment.ProductName + ", price : " + payment.Price + "\n";
            }
            return output;
        }

        public override int GetHashCode()
        {
            return this.firstName.GetHashCode() ^
                this.lastName.GetHashCode() ^
                this.middleName.GetHashCode() ^
                this.id.GetHashCode() ^
                this.mobilePhone.GetHashCode() ^
                this.email.GetHashCode() ^
                this.permanentAddress.GetHashCode() ^
                this.customerType.GetHashCode() ^
                this.payments.GetHashCode();
        }



        public object Clone()
        {
            var newCustomer = new Customer(this.firstName, this.middleName, this.lastName, this.id, this.permanentAddress, this.email, this.mobilePhone, new List<Payment>(), this.customerType);

            foreach (var payment in this.payments)
            {
                newCustomer.Payments.Add(new Payment(payment.ProductName, payment.Price));
            }

            return newCustomer;
        }

        public int CompareTo(Customer other)
        {
            string thisFullName = this.firstName + " " + this.middleName + " " + this.lastName;
            string otherFullName = other.firstName + " " + other.middleName + " " + other.lastName;

            if (!thisFullName.Equals(otherFullName))
            {
                return String.Compare(thisFullName, otherFullName, true, CultureInfo.CurrentCulture);
            }
            if (this.id != other.id)
            {
                return this.id - other.id;
            }
            return 0;
        }
    }
}
