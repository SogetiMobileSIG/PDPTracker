using System;
using System.Collections.Generic;
using Hackathon.Spade.Model;
using Xamarin.Forms;

namespace PDPTracker
{
    public class App : Application
    {
        public App ()
        {
            // The root page of your application
            MainPage = new NavigationPage (new HomePage()) { BarBackgroundColor = Color.FromRgb(98, 26, 65), BarTextColor = Color.White };
        }

        private static User _currentUser = new User { Name = "Hussain N. Abbasi" };

        public static User CurrentUser => _currentUser;

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}

