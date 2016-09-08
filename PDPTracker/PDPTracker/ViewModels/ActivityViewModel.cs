using System;
using System.Windows.Input;
using Hackathon.Spade.Model;
using Xamarin.Forms;

namespace PDPTracker
{
    public class ActivityViewModel : BaseViewModel
    {
        Page _parentPage;

        private string _title;
        public string ActivityTitle {
            get {
                return _title;
            }

            set {
                _title = value;
                OnPropertyChanged ();
            }
        }

        private Activity _activity;
        public Activity Activity
        {
            get { return _activity; }
            set { _activity = value; OnPropertyChanged();}
        }
         public string Description {             get { return Activity?.Description; }             set { Activity.Description = value; OnPropertyChanged (); }         }

        public DateTime? CompletedDate => Activity?.CompletedDate;

        public ActivityViewModel (Page page)
        {
            _parentPage = page;
            this.Activity = new Activity () { Id = DataService.Activities.Count + 1, CompletedDate = DateTime.Now };
            this.ActivityTitle = "New Activity";
        }

        public ActivityViewModel (Page page, int activityId)
        {
            _parentPage = page;
            this.Activity = DataService.GetActivityById (activityId);
            this.ActivityTitle = "Activity Details";
        }

        public void OnSave(){
            DataService.UpdateActivity (this.Activity);
        }
    }
}

