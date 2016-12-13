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

            mainMenu.ShowMenu();
        }

        private void NyOrder()
        {
            throw new NotImplementedException();
        }

        private void NyItem()
        {
            throw new NotImplementedException();
        }

        private void NyDato()
        {
            throw new NotImplementedException();
        }

        private void NyKunde()
        {
            Console.Clear();
            Console.WriteLine("You Choose to create a new customer");
            Console.WriteLine("")
        }
    }
}
