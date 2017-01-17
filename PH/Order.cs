using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH
{
    public class Order
    {
        

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
    }
}
