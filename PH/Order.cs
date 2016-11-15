using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH
{
    class Order
    {
        List<Order> orderList = new List<Order>();
        List<Customer> customerList = new List<Customer>();
        List<Date> dateList = new List<Date>();
        public Date DateSend { get; set; }
        public Date DateDelivery { get; set; }
        public Customer Customer { get; set; }

        public Order()
        {

        }
        public Order(Customer _customer, Date _date1, Date _date2)
        {
            Customer = _customer;
            DateSend = _date1;
            DateDelivery = _date2;
        }

        public void newOrder(string customerID, int dateIDSend, int dateIDDelivery)
        {
            List<Customer> customer = new List<Customer>();
            customer.AddRange(seachAndRetriveC(customerID));
            string dateIDSendS = "" + dateIDSend;
            string dateIDDeliveryS = "" + dateIDDelivery;

            if (dateList[dateIDSend].ToStringD().Split('.')[4].Contains(dateIDSendS) && dateList[dateIDDelivery].ToStringD().Split('.')[4].Contains(dateIDDeliveryS))
            {
                Order order = new Order(customer[0], dateList[dateIDSend], dateList[dateIDDelivery]);

                orderList.Add(order);
            }
            else
            {
                throw new Exception("One of the dates does not exist in the system");
            }  
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
            if (output.Count == 0)
            {
                throw new Exception("Search term did not match anything");
            }
            return output;
        }
        
    }
}
