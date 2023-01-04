using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductClasses
{
    public class Customer
    {
        //private variables
        private string email;
        private string firstName;
        private string lastName;
        private int id;
        private string phone;

        //default constructor
        public Customer() { }

        //overlaoded constructor
        public Customer(string cusEmail, string cusFname, string cusLname, int cusId, string cusPhone)
        {
            email = cusEmail;
            firstName = cusFname;
            lastName = cusLname;
            id = cusId;
            phone = cusPhone;
        }

        //bellow are the properties, with their getters and setters for each variable 
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Customer other = (Customer)obj;     
                  return  other.Email == Email &&
                    other.FirstName == FirstName &&
                    other.LastName == LastName &&
                    other.Id == Id &&
                    other.Phone == Phone;
            }
        }

        public override int GetHashCode()
        {
            return 13 + 7 * email.GetHashCode() +
                7 * firstName.GetHashCode() +
                7 * lastName.GetHashCode() +
                7 * id.GetHashCode() +
                7 * phone.GetHashCode();
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !c1.Equals(c2);
        }



        //the override and ToString
        public override string ToString()
        {
            return String.Format("Email: {0} First Name: {1} Last Name: {2} ID: {3:C} Phone: {4}", email, firstName, lastName, id, phone);
        }

    }
}
