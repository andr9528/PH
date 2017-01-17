using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PH;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class OrderTest
    {

        Repository repo = new Repository();
        List<Order> orderList = new List<Order>();

        [TestInitialize()]
        public void ClearLists()
        {
            repo.clearOrderList();
            repo.clearCustomerList();
            repo.clearDateList();
            repo.clearInventoryList();
        }

        [TestMethod]
        public void CreatingAOrderThatFails1()
        {
            try
            {
                repo.newOrder("1", "1", "2", "1", 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Search term did not find any Customers", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails2()
        {
            repo.newCustomer(1, "Marc", "Odensevej 111");

            try
            {
                repo.newOrder("1", "1", "2", "1", 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Did not get all desired dates", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails3()
        {
            repo.newCustomer(1, "Marc", "Odensevej 111");
            repo.newDate(3, 2, 1996, "Order", 1);

            try
            {
                repo.newOrder("1", "1", "2", "1", 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Did not get all desired dates", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails4()
        {
            repo.newCustomer(1, "Marc", "Odensevej 111");
            repo.newDate(3, 2, 1996, "Order", 1);
            repo.newDate(4, 12, 2006, "Delivery", 2);

            try
            {
                repo.newOrder("1", "1", "2", "1", 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Search term did not find the desired Item", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatFails5()
        {
            repo.newCustomer(1, "Marc", "Odensevej 111");
            repo.newDate(3, 2, 1996, "Order", 1);
            repo.newDate(4, 12, 2006, "Delivery", 2);
            repo.newItem("Candy", 1, 5.95);

            try
            {
                repo.newOrder("1", "1", "2", "1", 20);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("One of the chosen data does not exist, or you have asked for more then there is in the system", ex.Message);
            }
        }
        [TestMethod]
        public void CreatingAOrderThatIsSuccesfull()
        {
            repo.newCustomer(1, "Marc", "Odensevej 111");
            repo.newDate(3, 2, 1996, "Order", 1);
            repo.newDate(4, 12, 2006, "Delivery", 2);
            repo.newItem("Candy", 1, 5.95, 30);

            repo.newOrder("1", "1", "2", "1", 20);

            orderList = repo.getOrders();

            Assert.AreEqual(1, orderList.Count);
        }
    }
}
