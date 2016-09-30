using System;
using System.Collections.Generic;
using PDPTracker.Models;
using PDPTracker.Resources;
using Xamarin.Forms;

namespace PDPTracker
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel (Page page)
        {
            Title = PDPConstants.Profile;
            CurrentPage = page as ProfilePage;

            PopulateProfileItems ();
        }


        public List<ProfileItem> ProfileItems { get; set; }

        public User User => App.CurrentUser;

        void PopulateProfileItems ()
        {
            if(ProfileItems == null)
                ProfileItems = new List<ProfileItem> ();

            if (User == null)
                return;

            if(!string.IsNullOrWhiteSpace (User.Title)){
                ProfileItems.Add (new ProfileItem { Item = PDPConstants.Title, Value = User.Title });
            }

            if (!string.IsNullOrWhiteSpace (User.Practice)) {
                ProfileItems.Add (new ProfileItem { Item = PDPConstants.Practice, Value = User.Practice });
            }

            if(!string.IsNullOrWhiteSpace (User.Email)) {
                ProfileItems.Add (new ProfileItem { Item = PDPConstants.Email, Value = User.Email });
            }

            if(!string.IsNullOrWhiteSpace (User.ContactNumber)) {
                ProfileItems.Add (new ProfileItem { Item = PDPConstants.ContactNumber, Value = User.ContactNumber });
            }

            if(!string.IsNullOrWhiteSpace (User.FacebookLink)) {
                ProfileItems.Add (new ProfileItem { Item = PDPConstants.Facebook, Value = User.FacebookLink });
            }

            if(!string.IsNullOrWhiteSpace (User.TwitterHandle)) {
                ProfileItems.Add (new ProfileItem { Item = PDPConstants.Twitter, Value = User.TwitterHandle });
            }

            if(!string.IsNullOrWhiteSpace (User.LinkedInProfileLink)) {
                ProfileItems.Add (new ProfileItem { Item = PDPConstants.LinkedIn, Value = User.LinkedInProfileLink });
            }
        }
    }
}

