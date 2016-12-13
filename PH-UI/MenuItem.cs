namespace PH_UI
{
    internal class MenuItem
    {
        private MenuValg menuValg;
        private string name;

        internal MenuValg MenuValg { get { return menuValg; } set { menuValg = value; } }
        internal string Name { get { return name; } set { name = value; } }

        public MenuItem(string name, MenuValg menuValg)
        {
            Name = name;
            MenuValg = menuValg;
        }
    }
}