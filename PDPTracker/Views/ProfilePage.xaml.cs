using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PDPTracker
{
    public partial class ProfilePage : ContentPage
    {
        ProfileViewModel _vm;

        public ProfilePage ()
        {
            InitializeComponent ();
            _vm = new ProfileViewModel (this);
            BindingContext = _vm;
        }

        void Handle_ItemSelected (object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            // Clear selection
            var lv = sender as ListView;

            if (lv == null) return;

            if (lv.SelectedItem != null)
                lv.SelectedItem = null;
        }
    }
}

