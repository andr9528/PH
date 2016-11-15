using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH
{
    class Customer
    {
        public int CustomerID { get; internal set; }
        public string Name { get; internal set; }
        public string Address { get; internal set; }

        public Customer()
        {

        }
        public Customer(int _customerID, string _name, string _address)
        {
            CustomerID = _customerID;
            Name = _name;
            Address = _address;
        }
        public string ToStringC()
        {
            string output;

            output = CustomerID + ", " + Name + ", " + Address;
        
            return output;
        }
    }
}
