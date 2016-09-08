using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PDPTracker
{
    public class ProfileViewModel : BaseViewModel
    {
        ProfilePage _page;

        public ProfileViewModel (Page page)
        {
            _page = page as ProfilePage;

            PopulateProfileItems ();
        }

        void PopulateProfileItems ()
        {
            ProfileItems = new List<ProfileItem> {
                new ProfileItem { Item = "Title", Value = "Senior Consultant" },
                new ProfileItem { Item = "Practice", Value = "Digital Transformation (DT)" },
                new ProfileItem { Item = "Email", Value = "hussain.abbasi@us.sogeti.com" },
                new ProfileItem { Item = "Contact Number", Value = "832.606.6656" }
            };
        }

        public List<ProfileItem> ProfileItems { get; set; }

        private string _profileTitle = "Sogeti Profile";
        public string ProfileTitle {
            get {
                return _profileTitle;
            }
            set {
                _profileTitle = value;
                OnPropertyChanged ();
            }
        }

        public User User => App.CurrentUser;
    }
}

