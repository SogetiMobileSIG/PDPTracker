using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PDPTracker
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel _vm;

        public LoginPage ()
        {
            InitializeComponent ();
            _vm = new LoginViewModel (this);
            BindingContext = _vm;
        }

        protected override bool OnBackButtonPressed ()
        {
            return true;
        }
    }
}

