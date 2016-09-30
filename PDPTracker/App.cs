using PDPTracker.Models;
using Xamarin.Forms;

namespace PDPTracker
{
    public class App : Application
    {
        public App ()
        {
            if (Device.OS == TargetPlatform.iOS) {
                MainPage = new TabbedMainPage ();
            } else if (Device.OS == TargetPlatform.Android) {
                MainPage = new MasterDetailMainPage ();
            }
        }

        private static User _currentUser = new User { 
            Name = "Hussain N. Abbasi",
            Title = "Senior Consultant",
            Practice = "Digital Transformation",
            ContactNumber = "832-606-6656",
            FacebookLink = "https://www.facebook.com/hnabbasi",
            TwitterHandle = "hnabbasi",
            LinkedInProfileLink = "https://www.linkedin.com/in/hnabbasi"
        };

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

