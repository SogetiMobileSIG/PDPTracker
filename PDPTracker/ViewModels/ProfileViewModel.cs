using System;
using System.Collections.Generic;
using System.IO;
using PDPTracker.Models;
using PDPTracker.Resources;
using Xamarin.Forms;

namespace PDPTracker
{
    public class ProfileViewModel : BaseViewModel
    {
        #region Constructor

        public ProfileViewModel (Page page)
        {
            Title = PDPConstants.Profile;
            CurrentPage = page as ProfilePage;

            PopulateProfileItems ();
        }

        #endregion

        #region Properties

        public List<ProfileItem> ProfileItems { get; set; }

        public User User => App.CurrentUser;

        private ProfileItem _selectedItem;
        public ProfileItem SelectedItem {
            get { return _selectedItem; }
            set {
                if (Equals (_selectedItem, value))
                    return;

                _selectedItem = value;
                OnPropertyChanged ();

                if (value != null && value.IsWebLink)
                    OnSocialProfileTapped ();
            }
        }

        #endregion

        #region Private Methods

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

            if(!string.IsNullOrWhiteSpace (User.FacebookUsername)) {
                ProfileItems.Add (new ProfileItem { Item = PDPConstants.Facebook, Value = User.FacebookUsername, IsWebLink = true });
            }

            if(!string.IsNullOrWhiteSpace (User.TwitterHandle)) {
                ProfileItems.Add (new ProfileItem { Item = PDPConstants.Twitter, Value = User.TwitterHandle, IsWebLink = true });
            }

            if(!string.IsNullOrWhiteSpace (User.LinkedInUsername)) {
                ProfileItems.Add (new ProfileItem { Item = PDPConstants.LinkedIn, Value = User.LinkedInUsername, IsWebLink = true });
            }
        }

        void OnSocialProfileTapped ()
        {
            if (SelectedItem == null || SelectedItem.Value == null)
                return;

            string userProfile = string.Empty;

            switch (SelectedItem.Item) 
            {
                case PDPConstants.Facebook:
                    userProfile = Path.Combine (PDPConstants.FacebookLink, SelectedItem.Value);
                    break;

                case PDPConstants.Twitter:
                    userProfile = Path.Combine (PDPConstants.TwitterLink, SelectedItem.Value);
                    break;
            
                case PDPConstants.LinkedIn:
                    userProfile = Path.Combine (PDPConstants.LinkedInLink, SelectedItem.Value);
                    break;

            default:
                break;
            }

            LaunchBrowser (userProfile);

            // Clear selection
            SelectedItem = null;
        }

        void LaunchBrowser(string link) 
        {
            if (string.IsNullOrWhiteSpace (link))
                return;
            
            Uri uri;

            if(link.StartsWith ("www", StringComparison.Ordinal)) 
            {
                link = string.Concat ("http://", link);
            }
            uri = new Uri (link);

            Device.OpenUri (uri);
        }
        #endregion
    }
}

