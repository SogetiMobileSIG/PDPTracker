using System.Collections.Generic;
using PDPTracker.Resources;

namespace PDPTracker
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel ()
        {
            Title = PDPConstants.MasterMenu;
            InitializeMenu ();
        }

        private List<MasterMenuItem> _menuItems;          public List<MasterMenuItem> MenuItems {             get { return _menuItems; }             set { _menuItems = value; 
                OnPropertyChanged (); }         }

        void InitializeMenu ()
        {
            MenuItems = new List<MasterMenuItem> ();

            MenuItems.Add (new MasterMenuItem {
                Title = "Activities",
                IconSource = "icon.png",
                TargetType = typeof (HomePage)
            });
            MenuItems.Add (new MasterMenuItem {
                Title = "Profile",
                IconSource = "icon.png",
                TargetType = typeof (ProfilePage)
            });
        }

    }
}
