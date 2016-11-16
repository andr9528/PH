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
        List<Inventory> itemList = new List<Inventory>();

        public Date Date { get; set; }
        public Inventory Inventory { get; set; }

        public Date DateSend { get; set; }
        public Date DateDelivery { get; set; }
        public Customer Customer { get; set; }
        public Inventory Item { get; set; }
        public int Quantity { get; set; }

        public Order()
        {

        }
        public Order(Customer _customer, Date _date1, Date _date2, Inventory _item, int _quantity)
        {
            Customer = _customer;
            DateSend = _date1;
            DateDelivery = _date2;
            Item = _item;
            Quantity = _quantity;
        }

        public void newOrder(string customerID, int dateIDSend, int dateIDDelivery, string typeID, int quantity)
        {
            List<Customer> customer = new List<Customer>();
            customer.AddRange(Customer.seachAndRetriveC(customerID));
            string dateIDSendS = "" + dateIDSend;
            string dateIDDeliveryS = "" + dateIDDelivery;

            if (dateList[dateIDSend].ToStringD().Split('.')[4].Contains(dateIDSendS)
                && dateList[dateIDDelivery].ToStringD().Split('.')[4].Contains(dateIDDeliveryS)
                && itemList[0].ToStringI().Split(',')[0].Contains(typeID)
                && int.Parse(itemList[0].ToStringI().Split(',')[4]) >= quantity)
            {
                Order order = new Order(customer[0], dateList[dateIDSend], dateList[dateIDDelivery], itemList[0], quantity);

                orderList.Add(order);
            }
            else
            {
                throw new Exception("One of the chosen data does not exist, or you have asked for more then there is in the system");
            }  
        }
        public void getLists()
        {
            customerList = Customer.getCustomerList();
            dateList = Date.getDateList();
            itemList = Inventory.getInventoryList();
        }
        public List<Order> getOrders()
        {
            return orderList;
        }
        
    }
}
