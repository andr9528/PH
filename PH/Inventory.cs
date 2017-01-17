using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH
{
    public class Inventory
    {
        
        public int TypeID { get; set; }
        public int Quantity { get; set; }
        public string Desription { get; set; }
        public double Price { get; set; }

        public Inventory()
        {

        }
        public Inventory(int _typeID, string _description, double _price, int _quantity = 0)
        {
            TypeID = _typeID;
            Desription = _description;
            Price = _price;
            Quantity = _quantity;
        }
        public string ToStringI()
        {
            string output;

            string priceS = "" + Price;
            priceS = string.Format("{0:0.00}", Price);
            priceS = priceS.Replace(',', '.');

            output = TypeID + ", " + Desription + ", " + priceS + ", " + Quantity;

            return output;
        }
    }
}
