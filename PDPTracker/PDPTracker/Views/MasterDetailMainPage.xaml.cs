using System;
using System.Collections.Generic;
using PDPTracker.Resources;
using Xamarin.Forms;

namespace PDPTracker
{
    public partial class MasterDetailMainPage : MasterDetailPage
    {
        public MasterDetailMainPage ()
        {
            InitializeComponent ();
            SubscribeEvents ();
        }

        void SubscribeEvents ()
        {
            menuPage.ListView.ItemSelected += UpdateDetailPage;
            MessagingCenter.Subscribe<MenuPage, Type> (this, PDPConstants.MenuItemTapped, UpdateDetailPage);
        }

        void UpdateDetailPage (MenuPage arg1, Type arg2)
        {
            Detail = new PDPNavigationPage ((Page)Activator.CreateInstance (arg2));
            ResetMenu ();
        }

        void UpdateDetailPage(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterMenuItem;
            if (item == null) 
                return;

            Detail = new PDPNavigationPage ((Page)Activator.CreateInstance(item.TargetType));
            ResetMenu ();
        }

        void ResetMenu()
        {
            menuPage.ListView.SelectedItem = null;
            IsPresented = false;
        }

        protected override void OnAppearing ()
        {
            base.OnAppearing ();
        }
        protected override void OnDisappearing ()
        {
            //menuPage.ListView.ItemSelected -= UpdateDetailPage;
            //MessagingCenter.Unsubscribe<MenuPage> (this, PDPConstants.MenuItemTapped);
            base.OnDisappearing ();
        }
    }
}
