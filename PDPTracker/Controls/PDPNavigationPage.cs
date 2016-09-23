using System;
using PDPTracker.Resources;
using Xamarin.Forms;

namespace PDPTracker
{
    public class PDPNavigationPage : NavigationPage
    {
        public PDPNavigationPage (Page root) : base (root)
        {
            BarBackgroundColor = Color.FromHex (PDPConstants.PrimaryColorHex);
            BarTextColor = Color.FromHex (PDPConstants.ToolbarTextColor);
        }
    }
}
