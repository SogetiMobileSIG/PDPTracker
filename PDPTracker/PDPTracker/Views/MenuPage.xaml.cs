using System;
using System.Collections.Generic;
using PDPTracker.Resources;
using Xamarin.Forms;

namespace PDPTracker
{
    public partial class MenuPage : ContentPage
    {
        private MenuViewModel _viewModel;
        public ListView ListView => listView;

        public MenuPage ()
        {
            InitializeComponent ();
            _viewModel = new MenuViewModel ();

            BindingContext = _viewModel;
            ProfileGrid.BackgroundColor = Color.FromHex (PDPConstants.PrimaryColorHex);
        }

        void Profile_Tapped (object sender, EventArgs e)
        {
            MessagingCenter.Send (this, PDPConstants.MenuItemTapped, typeof(ProfilePage));
        }
    }
}
