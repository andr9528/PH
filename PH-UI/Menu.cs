using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PH;

namespace PH_UI
{
    internal delegate void MenuValg();
    class Menu
    {

        List<MenuItem> menu = new List<MenuItem>();
        internal void ShowMenu()
        {
            Console.Clear();
            int counter = 0;

            Console.Write(counter + ": Exit");
            counter++;

            foreach (MenuItem item in menu)
            {
                Console.WriteLine(counter + ": " + item.Name);
                counter++;
            }
        }

        internal void Add(string name, MenuValg menuValg)
        {
            MenuItem item = new MenuItem(name, menuValg);

            menu.Add(item);
        }
    }
}
