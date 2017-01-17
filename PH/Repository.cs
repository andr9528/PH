using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH
{
    class Repository
    {
        static List<Customer> customerList = new List<Customer>();
        static List<Date> dateList = new List<Date>();
        static List<Inventory> inventoryList = new List<Inventory>();
        static List<Order> orderList = new List<Order>();

        // Customer

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
        public List<Customer> getCustomerList()
        {
            return customerList;
        }
        public void clearCustomerList()
        {
            customerList.Clear();
        }

        // Date

        public void newDate(int day, int month, int year, string type, int dateID)
        {
            bool doesNotAlreadyExist = true;
            string typeLow = type.ToLowerInvariant();
            string typeChapFirst = type.Substring(0, 1).ToUpperInvariant() + type.Substring(1);

            foreach (Date date in dateList)
            {
                if (date.ToStringD().Split('.')[4].Contains(dateID.ToString()))
                {
                    doesNotAlreadyExist = false;
                }
            }

            if (day <= 31 && day >= 1
                && month <= 12 && month >= 1
                && (typeLow == "order" || typeLow == "delivery")
                && doesNotAlreadyExist == true)
            {
                Date date = new Date(day, month, year, typeChapFirst, dateID);

                dateList.Add(date);
            }
            else
            {
                throw new Exception("invalid day or month, type can only be *Order* or *Delivery*, the dateID must not already exist ");
            }
        }
        public List<Date> searchAndRetriveD(string orderDate, string DeliveryDate)
        {
            List<Date> output = new List<Date>();

            foreach (Date date in dateList)
            {
                if (date.ToStringD().Split('.')[4].Contains(orderDate))
                {
                    output.Add(date);
                }
            }
            foreach (Date date in dateList)
            {
                if (date.ToStringD().Split('.')[4].Contains(DeliveryDate))
                {
                    output.Add(date);
                }
            }
            if (output.Count <= 1)
            {
                throw new Exception("Did not get all desired dates");
            }
            return output;
        }
        public List<Date> getDateList()
        {
            return dateList;
        }
        public void clearDateList()
        {
            dateList.Clear();
        }

        // Inventory
        
        public void newItem(string description, int typeID, double price, int quantity = 0)
        {
            bool doesNotAlreadyExist = true;

            foreach (Inventory good in inventoryList)
            {
                if (good.ToStringI().Split(',')[0].Contains(typeID.ToString()))
                {
                    doesNotAlreadyExist = false;
                }
            }
            if (price >= 0.00 && quantity >= 0 && doesNotAlreadyExist == true)
            {
                Inventory item = new Inventory(typeID, description, price, quantity);

                inventoryList.Add(item);
            }
            else
            {
                throw new Exception("price and quantity, if one is defined, need to be above or equal to 0, the typeID must not already exist");
            }
        }
        public List<Inventory> seachAndRetriveI(string searchTerm)
        {
            List<Inventory> output = new List<Inventory>();

            foreach (Inventory item in inventoryList)
            {
                if (item.ToStringI().Split(',')[0].Contains(searchTerm))
                {
                    output.Add(item);
                }
            }
            if (output.Count == 0)
            {
                throw new Exception("Search term did not find the desired Item");
            }
            return output;
        }
        public List<Inventory> getInventoryList()
        {
            return inventoryList;
        }
        public void clearInventoryList()
        {
            inventoryList.Clear();
        }

        // Order

        public void newOrder(string customerID, string dateIDOrder, string dateIDDelivery, string itemID, int quantity)
        {
            List<Customer> customers = new List<Customer>();
            List<Date> dates = new List<Date>();
            List<Inventory> item = new List<Inventory>();

            customers.AddRange(seachAndRetriveC(customerID));
            dates.AddRange(searchAndRetriveD(dateIDOrder, dateIDDelivery));
            item.AddRange(seachAndRetriveI(itemID));

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
        // General

        public void clearAllLists()
        {
            orderList.Clear();
            inventoryList.Clear();
            dateList.Clear();
            inventoryList.Clear();
        }
    }
}
