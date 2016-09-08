using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PDPTracker
{
    public partial class HomePage : ContentPage
    {
        HomeViewModel _vm;

        public HomePage ()
        {
            InitializeComponent();
            _vm = new HomeViewModel (this);
            BindingContext = _vm;

            InitializeToolbar ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ActivitiesList.ItemsSource = null;
            ActivitiesList.ItemsSource = _vm.Activities;

            if (ActivitiesList.SelectedItem != null)
                ActivitiesList.SelectedItem = null;
        }

        private void InitializeToolbar ()
        {
            var addButton = new ToolbarItem {
                Text = "+",
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };

            addButton.Clicked += async (sender, args) => {
                await Navigation.PushAsync (new ActivityPage ());
            };

            ToolbarItems.Add (addButton);

            var profileButton = new ToolbarItem {
                Text = "O",
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            profileButton.Clicked += async (sender, e) => {
                await Navigation.PushAsync (new ProfilePage ());
            };

            ToolbarItems.Add (profileButton);
        }
    }
}

