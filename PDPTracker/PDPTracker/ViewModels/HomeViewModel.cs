using System;
using System.Collections.Generic;
using Hackathon.Spade.Model;
using PDPTracker.Resources;
using Xamarin.Forms;

namespace PDPTracker
{
    public class HomeViewModel : BaseViewModel
    {
        #region Private Fields

        private readonly Page _parentPage;

        #endregion

        #region Properties

        public bool IsLoggedIn => DataService.Instance.IsLoginSuccessful();

        public List<Activity> Activities {
            get { return DataService.Instance.Activities; }
            set 
            { 
                DataService.Instance.Activities = value; 
                OnPropertyChanged ();
            }
        }

        public Activity SelectedActivity {
            set
            {
                if (value == null) return;

                _parentPage.Navigation.PushAsync(new ActivityPage(value.Id));
            }
        }

        #endregion

        #region Constructor

        public HomeViewModel (Page page)
        {
            Title = PDPConstants.Activities;
            _parentPage = page;

            if (!IsLoggedIn)
                _parentPage.Navigation.PushModalAsync (new LoginPage ());

            if (Activities == null || Activities.Count == 0)
                PopulateSampleData ();
        }

        #endregion

        #region Private Methods

        private void PopulateSampleData ()
        {
            Activities = new List<Activity>
            {
                new Activity { Id = 1, Description = "Finished Xamarin certification", CompletedDate = DateTime.Parse("10-Oct-2015") },
                new Activity { Id = 2, Description = "Flew to Atlanta for Newell sales meeting", CompletedDate = DateTime.Parse("12-Dec-2015") },
                new Activity { Id = 3, Description = "Sat in ADP meeting for Stu", CompletedDate = DateTime.Parse("15-Jan-2016") },
                new Activity { Id = 4, Description = "Finished MSCD certification", CompletedDate = DateTime.Parse("1-Feb-2016") },
                new Activity { Id = 5, Description = "Transocean lunch and learn", CompletedDate = DateTime.Parse("25-May-2016") }
            };
        }

        #endregion

    }
}

