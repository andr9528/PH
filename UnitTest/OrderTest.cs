using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PH;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class OrderTest
    {
        // dummy objects
        // customer.newCustomer(1, "Marc", "Odensevej 111");
        // date.newDate(3, 2, 1996, "Send", 1);
        // date.newDate(4, 12, 2006, "Delivery", 2);
        // inventory.newItem("Candy", 1, 5.95, 30);

        Order order = new Order();
        Customer customer = new Customer();
        Date date = new Date();
        Inventory inventory = new Inventory();

        List<Order> orderList = new List<Order>();

        [TestInitialize()]
        public void ClearLists()
        {
            order.clearLists();
            customer.clearCustomerList();
            date.clearDateList();
            inventory.clearInventoryList();
        }

        [TestMethod]
        public void CreatingAOrderThatFails1()
        {
            try
            {
                order.newOrder(1, 1, 2, 1, 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Search term did not match anything", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails2()
        {
            customer.newCustomer(1, "Marc", "Odensevej 111");
            order.getLists();
            try
            {
                order.newOrder(1, 1, 2, 1, 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("One of the chosen data does not exist, or you have asked for more then there is in the system", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails3()
        {
            customer.newCustomer(1, "Marc", "Odensevej 111");
            date.newDate(3, 2, 1996, "Order", 1);
            order.getLists();
            try
            {
                order.newOrder(1, 1, 2, 1, 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("One of the chosen data does not exist, or you have asked for more then there is in the system", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails4()
        {
            customer.newCustomer(1, "Marc", "Odensevej 111");
            date.newDate(3, 2, 1996, "Order", 1);
            date.newDate(4, 12, 2006, "Delivery", 2);
            order.getLists();
            try
            {
                order.newOrder(1, 1, 2, 1, 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("One of the chosen data does not exist, or you have asked for more then there is in the system", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails5()
        {
            customer.newCustomer(1, "Marc", "Odensevej 111");
            date.newDate(3, 2, 1996, "Order", 1);
            date.newDate(4, 12, 2006, "Delivery", 2);
            inventory.newItem("Candy", 1, 5.95);
            order.getLists();
            try
            {
                order.newOrder(1, 1, 2, 1, 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("One of the chosen data does not exist, or you have asked for more then there is in the system", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatIsSuccesfull()
        {
            customer.newCustomer(1, "Marc", "Odensevej 111");
            date.newDate(3, 2, 1996, "Order", 1);
            date.newDate(4, 12, 2006, "Delivery", 2);
            inventory.newItem("Candy", 1, 5.95, 30);
            order.getLists();
            
            order.newOrder(1, 1, 2, 1, 20);

            orderList = order.getOrders();

            Assert.AreEqual(1, orderList.Count);
        }
    }
}
