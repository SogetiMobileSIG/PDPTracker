using System;
using System.Collections.Generic;
using System.Linq;
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
            RefreshList ();
        }

        private void InitializeToolbar ()
        {
            var addButton = new ToolbarItem {
                Text = "ADD",
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };
            addButton.SetBinding (MenuItem.CommandProperty, "NewActivityCommand");

            ToolbarItems.Add (addButton);
        }

        void Delete_Clicked (object sender, System.EventArgs e)
        {
            var menuItem = (MenuItem)sender;

            if (!_vm.DeleteActivityCommand.CanExecute (menuItem.CommandParameter))
                return;
            
            _vm.DeleteActivityCommand.Execute (menuItem.CommandParameter);
            RefreshList ();
        }

        void Handle_Refreshing (object sender, System.EventArgs e)
        {
            var lv = (ListView)sender;
            RefreshList ();
            lv.IsRefreshing = false;
        }

        void RefreshList()
        {
            ActivitiesList.ItemsSource = null;
            ActivitiesList.ItemsSource = _vm.Activities;

            ActivitiesList.SelectedItem = null;

            ActivitiesList.IsVisible = _vm.Activities.Any ();
            NoActivitiesLabel.IsVisible = !_vm.Activities.Any ();
        }
    }
}

