using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH
{
    public class Customer
    {
        static List<Customer> customerList = new List<Customer>();
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
        public void newCustomer(int customerID, string name, string address)
        {
            bool doesNotAlreadyExist = true;

            foreach (Customer customer in customerList)
            {
                if (customer.ToStringC().Split(',')[0].Contains(customerID.ToString()))
                {
                    doesNotAlreadyExist = false;
                }
            }
            if (doesNotAlreadyExist == true)
            {
                Customer customer = new Customer(customerID, name, address);

                customerList.Add(customer); 
            }
        }
        public List<Customer> getCustomerList()
        {
            return customerList;
        }
        public List<Customer> seachAndRetriveC(string searchTerm)
        {
            List<Customer> output = new List<Customer>();

            foreach (Customer customer in customerList)
            {
                if (customer.ToStringC().Split(',')[0].Contains(searchTerm))
                {
                    output.Add(customer);
                }
            }
            if (output.Count < 1)
            {
                throw new Exception("Search term did not find any Customers");
            }
            return output;
        }
        public string ToStringC()
        {
            string output;

            output = CustomerID + ", " + Name + ", " + Address;
        
            return output;
        }
        public void clearCustomerList()
        {
            customerList.Clear();
        }
    }
}
