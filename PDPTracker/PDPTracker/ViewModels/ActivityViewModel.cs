using System;
using System.Windows.Input;
using Hackathon.Spade.Model;
using PDPTracker.Resources;
using Xamarin.Forms;

namespace PDPTracker
{
    public class ActivityViewModel : BaseViewModel
    {
        #region Private Fields

        private Page _parentPage;

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

        #region Constructors

        public ActivityViewModel (Page page)
        {
            _parentPage = page;
            this.Activity = new Activity () { Id = DataService.Instance.Activities.Count + 1, CompletedDate = DateTime.Now };
            Title = PDPConstants.NewActivity;
        }

        public ActivityViewModel (Page page, int activityId)
        {
            _parentPage = page;
            this.Activity = DataService.Instance.GetActivityById (activityId);
            Title = PDPConstants.ActivityDetails;
        }

        #endregion

        #region Private Methods

        private void OnSave () => DataService.Instance.UpdateActivity (this.Activity);

        #endregion
    }
}

