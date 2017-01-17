using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PH;

namespace PH_UI
{
    class Program
    {
        Menu mainMenu = new Menu();
        Repository repo = new Repository();
        int listen = -1;
        bool confirmConvert;
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.run();
        }

        private void run()
        {
            mainMenu.Add("Opret Kunde", new MenuValg(NyKunde));
            mainMenu.Add("Opret Dato", new MenuValg(NyDato));
            mainMenu.Add("Opret Item", new MenuValg(NyItem));
            mainMenu.Add("Opret Order", new MenuValg(NyOrder));

            while (listen != 0)
            {
                try
                {
                mainMenu.ShowMenu();
                confirmConvert = int.TryParse(Console.ReadLine(), out listen);

                if (confirmConvert == false)
                {
                    listen = -1;
                }
                switch (listen)
                {
                    case 1:
                        mainMenu.menu[0].MenuValg();
                        break;
                    case 2:
                        mainMenu.menu[1].MenuValg();
                        break;
                    case 3:
                        mainMenu.menu[2].MenuValg();
                        break;
                    case 4:
                        //mainMenu.menu[3].MenuValg();
                        break;  
                    default:
                        break;
                }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong - " + e.Message);
                    Console.ReadLine();
                    throw;
                }
            }
        }

        private void NyOrder()
        {
            throw new NotImplementedException();
        }

        private void NyItem()
        {
            int id;
            string description;
            int quantity;
            double price;
            
            Console.Clear();
            Console.WriteLine("You Choose to create a new item");
            Console.WriteLine("Give me an ID for this item, this number needs to be above 0, and not have been used before");
            int.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("Give me a short description of the item, e.g a name");
            description = Console.ReadLine();
            Console.WriteLine("Give me the price of this item, use *.* as the comma");
            double.TryParse(Console.ReadLine(), out price);
            Console.WriteLine("Give me quantity of this item in storage, if not value is given or a invalid value is given, it will be set too 0");
            int.TryParse(Console.ReadLine(), out quantity);


            repo.newItem(description, id, price, quantity);

            Console.WriteLine("You created the item with the description " + description + ", with a price of " + price + ", with the id " + id + " and the quantity in storage of " + quantity);
            Console.ReadLine();
        }

        private void NyDato()
        {
            int id;
            string type;
            int year;
            int month;
            int day;

            Console.Clear();
            Console.WriteLine("You Choose to create a new date");
            Console.WriteLine("Give me an ID for this date, this number needs to be above 0, and not have been used before");
            int.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("Give me the day of this date, it needs to be between 1 and 31");
            int.TryParse(Console.ReadLine(), out day);
            Console.WriteLine("Give me the month of this date, it needs to be between 1 and 12");
            int.TryParse(Console.ReadLine(), out month);
            Console.WriteLine("Give me the year of this date");
            int.TryParse(Console.ReadLine(), out year);
            Console.WriteLine("Give me the type of date, is it a delivery or order date? accepts order or delivery");
            type = Console.ReadLine();

            repo.newDate(day, month, year, type, id);

            Console.WriteLine("You created the date " + day + "." + month + "." + year + " which is a " + type + " with a id of " + id);
            Console.ReadLine();

        }

        private void NyKunde()
        {
            int id;
            string name;
            string address;

            Console.Clear();
            Console.WriteLine("You Choose to create a new customer");
            Console.WriteLine("Give me an ID for this person, this number needs to be above 0, and not have been used before");
            int.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("Give me the name of this person");
            name = Console.ReadLine();
            Console.WriteLine("Give me the address for this person");
            address = Console.ReadLine();

            repo.newCustomer(id, name, address);

            Console.WriteLine("You just created a new custumer with the name " + name + ", the addres " + address + " and the id " + id);
            Console.ReadLine();
        }
    }
}
