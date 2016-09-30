using System;
using System.Windows.Input;
using PDPTracker.Models;
using PDPTracker.Resources;
using Xamarin.Forms;

namespace PDPTracker
{
    public class ActivityViewModel : BaseViewModel
    {
        #region Private Fields

        readonly IDataService _dataService;

        #endregion

        #region Constructors

        public ActivityViewModel (Page page, int activityId = -1)
        {
            CurrentPage = page;
            _dataService = new DataService ();

            if (activityId < 0) {
                this.Activity = new Activity () { CompletedDate = DateTime.Now };
                Title = PDPConstants.NewActivity;
            } else {
                this.Activity = _dataService.GetActivityById (activityId);
                Title = PDPConstants.ActivityDetails;
            }
        }

        #endregion

        #region Properties

        private Activity _activity;
        public Activity Activity {
            get { return _activity; }
            set { _activity = value; OnPropertyChanged (); }
        }

        public string Description {
            get { return Activity?.Description; }
            set { Activity.Description = value; OnPropertyChanged (); }
        }

        public DateTime? CompletedDate => Activity?.CompletedDate;

        #endregion

        #region Commands

        public ICommand SaveCommand => new Command (OnSave);

        #endregion

        #region Private Methods

        private void OnSave () => _dataService.UpdateActivity (this.Activity);

        #endregion
    }
}

