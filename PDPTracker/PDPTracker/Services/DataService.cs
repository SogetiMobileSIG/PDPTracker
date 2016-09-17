using System;
using System.Collections.Generic;
using PDPTracker.Models;

namespace PDPTracker
{
    public class DataService : IDataService
    {
        private static List<Activity> _activities;

        /// <summary>
        /// Gets all activities.
        /// </summary>
        /// <returns>List of all activities</returns>
        public List<Activity> GetActivities (){

            if(_activities == null) {
                _activities = new List<Activity> 
                {
                    new Activity { Id = 1, Description = "Finished Xamarin certification", CompletedDate = DateTime.Parse("10-Oct-2015") },
                    new Activity { Id = 2, Description = "Flew to Atlanta for Newell sales meeting", CompletedDate = DateTime.Parse("12-Dec-2015") },
                    new Activity { Id = 3, Description = "Sat in ADP meeting for Stu", CompletedDate = DateTime.Parse("15-Jan-2016") },
                    new Activity { Id = 4, Description = "Finished MSCD certification", CompletedDate = DateTime.Parse("1-Feb-2016") },
                    new Activity { Id = 5, Description = "Transocean lunch and learn", CompletedDate = DateTime.Parse("25-May-2016") }
                };
            }
            return _activities;
        }

        /// <summary>
        /// Gets the activity by id.
        /// </summary>
        /// <returns>The activity by id.</returns>
        /// <param name="activityId">Activity Id.</param>
        public Activity GetActivityById (int activityId){
            return _activities.Find (x => x.Id == activityId);
        }

        /// <summary>
        /// Updates the activity.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public void UpdateActivity (Activity activity)
        {
            var index = _activities.FindIndex (x => x.Id == activity.Id);

            if(index > -1)
                _activities.RemoveAt (index);

            _activities.Insert (0, activity);
        }
    }
}

