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
        static List<Customer> customerList = new List<Customer>();
        static List<Date> dateList = new List<Date>();
        static List<Inventory> itemList = new List<Inventory>();

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

        public void newOrder(int customerID, int dateIDOrder, int dateIDDelivery, int itemID, int quantity) // doesn't handle dates being in a different order then 1, 2, 3...
        {
            List<Customer> customer = new List<Customer>();
            List<Date> dates = new List<Date>();
            string customerIDS = "" + customerID;
            string itemIDS = "" + itemID;
            string dateIDOrderS = "" + dateIDOrder;
            string dateIDDeliveryS = "" + dateIDDelivery;
            customer.AddRange(Customer.seachAndRetriveC(customerIDS));
            dates.AddRange(Date.searchAndRetriveD(dateIDOrderS, dateIDDeliveryS));

            if (dates[0].ToStringD().Split('.')[3].Contains("Order")
                && dates[1].ToStringD().Split('.')[3].Contains("Delivery")
                && itemList[0].ToStringI().Split(',')[0].Contains(itemIDS)
                && int.Parse(itemList[0].ToStringI().Split(',')[4]) >= quantity
                && customer.Count >= 1) 
            {
                Order order = new Order(customer[0], dateList[dateIDOrder], dateList[dateIDDelivery], itemList[0], quantity);

                orderList.Add(order);
            }
            else
            {
                throw new Exception("One of the chosen data does not exist, or you have asked for more then there is in the system");
            }  
        }
        public void getLists() // does not handle null lists
        {
            if (Customer.getCustomerList().Count != 0 && Customer.getCustomerList().Any())
            {
                customerList = Customer.getCustomerList();
            }
            if (Date.getDateList().Count != 0 && Date.getDateList().Any())
            {
                dateList = Date.getDateList();
            }
            if (Inventory.getInventoryList().Count != 0 && Inventory.getInventoryList().Any())
            {
                itemList = Inventory.getInventoryList();
            }
        }
        public List<Order> getOrders()
        {
            return orderList;
        }
        public void clearLists()
        {
            orderList.Clear();
            customerList.Clear();
            dateList.Clear();
            itemList.Clear();
        }
        
    }
}
