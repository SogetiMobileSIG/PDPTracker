using System;
using System.Collections.Generic;
using Hackathon.Spade.Model;

namespace PDPTracker
{
    public class DataService
    {
        public static DataService Instance { get; private set; } = new DataService ();

        public List<Activity> Activities {
            get;
            set;
        }

        public Activity GetActivityById (int aId){
            return Activities.Find (x => x.Id == aId);
        }

        public void UpdateActivity (Activity activity)
        {
            var index = Activities.FindIndex (x => x.Id == activity.Id);

            if(index > -1)
                Activities.RemoveAt (index);

            Activities.Insert (0, activity);
        }

        public bool IsLoginSuccessful () => RememberMe;

        public bool RememberMe { get; set; } = true;
    }
}

