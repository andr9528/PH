using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PH;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class OrderTest
    {

        Order order = new Order();

        List<Order> orderList = new List<Order>();

        [TestInitialize()]
        public void ClearLists()
        {
            order.clearOrders();
            order.customer.clearCustomerList();
            order.date.clearDateList();
            order.inventory.clearInventoryList();
        }

        [TestMethod]
        public void CreatingAOrderThatFails1()
        {
            try
            {
                order.newOrder("1", "1", "2", "1", 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Search term did not find any Customers", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails2()
        {
            order.customer.newCustomer(1, "Marc", "Odensevej 111");

            try
            {
                order.newOrder("1", "1", "2", "1", 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Did not get all desired dates", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails3()
        {
            order.customer.newCustomer(1, "Marc", "Odensevej 111");
            order.date.newDate(3, 2, 1996, "Order", 1);

            try
            {
                order.newOrder("1", "1", "2", "1", 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Did not get all desired dates", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails4()
        {
            order.customer.newCustomer(1, "Marc", "Odensevej 111");
            order.date.newDate(3, 2, 1996, "Order", 1);
            order.date.newDate(4, 12, 2006, "Delivery", 2);

            try
            {
                order.newOrder("1", "1", "2", "1", 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Search term did not find the desired Item", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails5()
        {
            order.customer.newCustomer(1, "Marc", "Odensevej 111");
            order.date.newDate(3, 2, 1996, "Order", 1);
            order.date.newDate(4, 12, 2006, "Delivery", 2);
            order.inventory.newItem("Candy", 1, 5.95);

            try
            {
                order.newOrder("1", "1", "2", "1", 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("One of the chosen data does not exist, or you have asked for more then there is in the system", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatIsSuccesfull()
        {
            order.customer.newCustomer(1, "Marc", "Odensevej 111");
            order.date.newDate(3, 2, 1996, "Order", 1);
            order.date.newDate(4, 12, 2006, "Delivery", 2);
            order.inventory.newItem("Candy", 1, 5.95, 30);

            order.newOrder("1", "1", "2", "1", 20);

            orderList = order.getOrders();

            Assert.AreEqual(1, orderList.Count);
        }
    }
}
