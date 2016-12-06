using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH
{
    public class Order
    {
        static List<Order> orderList = new List<Order>();

        public Date date = new Date();
        public Customer customer = new Customer();
        public Inventory inventory = new Inventory();

        public Date DateSend { get; set; }
        public Date DateDelivery { get; set; }
        public Customer Customer { get; set; }
        public Inventory Item { get; set; }
        public int Quantity { get; set; }

        public Order()
        {

        }
        public Order(Customer _customer, Date _dateOrder, Date _dateDelivery, Inventory _item, int _quantity)
        {
            Customer = _customer;
            DateSend = _dateOrder;
            DateDelivery = _dateDelivery;
            Item = _item;
            Quantity = _quantity;
        }

        public void newOrder(string customerID, string dateIDOrder, string dateIDDelivery, string itemID, int quantity)
        {
            List<Customer> customers = new List<Customer>();
            List<Date> dates = new List<Date>();
            List<Inventory> item = new List<Inventory>();

            customers.AddRange(customer.seachAndRetriveC(customerID));
            dates.AddRange(date.searchAndRetriveD(dateIDOrder, dateIDDelivery));
            item.AddRange(inventory.seachAndRetriveI(itemID));

            if (dates[0].ToStringD().Split('.')[3].Contains("Order")
                && dates[1].ToStringD().Split('.')[3].Contains("Delivery")
                && int.Parse(item[0].ToStringI().Split(',')[3]) >= quantity
                && customers.Count >= 1) 
            {
                Order order = new Order(customers[0], dates[0], dates[1], item[0], quantity);

                orderList.Add(order);
            }
            else
            {
                throw new Exception("One of the chosen data does not exist, or you have asked for more then there is in the system");
            }  
        }

        public List<Order> getOrders()
        {
            return orderList;
        }
        public void clearOrders()
        {
            orderList.Clear();

        }
        
    }
}
