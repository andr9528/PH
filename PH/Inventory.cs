using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH
{
    public class Inventory
    {
        List<Inventory> inventoryList = new List<Inventory>();
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
        public List<Inventory> showInventory()
        {
            return inventoryList;
        }
        public void editInventory(string edit)
        {

        }
        public void newItem(string description, int typeID, double price)
        {
            Inventory item = new Inventory(typeID, description, price);

            inventoryList.Add(item);
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
                throw new Exception("Search term did not match anything");
            }
            return output;
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
