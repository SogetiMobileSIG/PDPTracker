using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using PDPTracker.Models;
using PDPTracker.Resources;
using Xamarin.Forms;

namespace PDPTracker
{
    public class HomeViewModel : BaseViewModel
    {
        #region Private Fields
        readonly IDataService _dataService;
        #endregion

        #region Constructor

        public HomeViewModel (Page page)
        {
            Title = PDPConstants.Activities;
            CurrentPage = page;
            _dataService = new DataService ();

            if (!IsLoggedIn)
                CurrentPage.Navigation.PushModalAsync (new LoginPage ());
        }

        #endregion

        #region Properties

        public bool IsLoggedIn => true;

        public List<Activity> Activities => _dataService.GetActivities ();

        public Activity SelectedActivity {
            set
            {
                if (value != null) 
                    CurrentPage.Navigation.PushAsync(new ActivityPage(value.Id));
            }
        }

        #endregion

        #region Commands

        public ICommand NewActivityCommand => new Command (OnNewActivity);

        void OnNewActivity (object obj)
        {
            CurrentPage.Navigation.PushAsync (new ActivityPage ());
        }

        public ICommand DeleteActivityCommand => new Command (OnDeleteActivity);

        async void OnDeleteActivity (object obj)
        {
            var activity = (Activity)obj;

            if (activity == null) 
                return;

            if (await CurrentPage.DisplayAlert ("Delete", "Are you sure you want to delete this activity?", "Yes", "No"))
                _dataService.DeleteActivity (activity.Id);
        }

        #endregion

        #region Private Methods

        #endregion

    }
}

