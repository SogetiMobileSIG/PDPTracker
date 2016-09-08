using System;
using System.Collections.Generic;
using Hackathon.Spade.Model;

namespace PDPTracker
{
    public static class DataService
    {
        public static List<Activity> Activities {
            get;
            set;
        }

        public static Activity GetActivityById (int aId){
            return Activities.Find (x => x.Id == aId);
        }

        public static void UpdateActivity (Activity activity)
        {
            var index = Activities.FindIndex (x => x.Id == activity.Id);

            if(index > -1)
                Activities.RemoveAt (index);

            Activities.Insert (0, activity);
        }

        public static bool IsLoginSuccessful () => RememberMe;

        public static bool RememberMe {
            get;
            set;
        }
    }
}

