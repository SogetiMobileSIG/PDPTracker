using System;
using PDPTracker.Models;
using PDPTracker.Resources;
using Xamarin.Forms;

namespace PDPTracker
{
    public partial class MasterDetailMainPage : MasterDetailPage
    {
        private bool _isSubscribed;

        public MasterDetailMainPage ()
        {
            InitializeComponent ();
            SubscribeEvents ();
        }

        void SubscribeEvents ()
        {
            if (_isSubscribed)
                return;
            
            menuPage.ListView.ItemSelected += UpdateDetailPage;
            MessagingCenter.Subscribe<MenuPage, Type> (this, PDPConstants.MenuItemTapped, UpdateDetailPage);
            _isSubscribed = true;
        }


        void UnsubscribeEvents ()
        {
            if (!_isSubscribed)
                return;

            menuPage.ListView.ItemSelected -= UpdateDetailPage;
            MessagingCenter.Unsubscribe<MenuPage, Type>(this, PDPConstants.MenuItemTapped);
            _isSubscribed = false;
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
            SubscribeEvents ();
        }
        protected override void OnDisappearing ()
        {
            UnsubscribeEvents ();
            base.OnDisappearing ();
        }
    }
}
